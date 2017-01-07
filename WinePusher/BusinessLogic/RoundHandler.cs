using System;
using System.Collections.Generic;
using System.Linq;
using WinePusher.Models;

namespace WinePusher.BusinessLogic
{
    class RoundHandler
    {
        WinePusherDBEntities wpe = new WinePusherDBEntities();

        public RoundHandler()
        {
        }

        public void CreateRound(int WineId, DateTime RoundDate, decimal Cost, string Status)
        {
            Rounds round = new Rounds();
            round.WineId = WineId;
            round.Date = RoundDate;
            round.Status = Status;
            round.Cost = Cost;

            try
            {
                wpe.Rounds.Add(round);
                wpe.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<RoundListItem> ListRounds()
        {
            var statusList = new[] { "A", "B", "C" };

            List<RoundListItem> roundListItemList = wpe.Rounds
                                                   .Join(wpe.Wines,
                                                      round => round.WineId,
                                                      wine => wine.Id,
                                                      (round, wine) => new { round, wine })
                                                   .GroupJoin(wpe.Orders,
                                                      o => o.round.Id,
                                                      order => order.RoundId,
                                                      (o, order) => new { o, orderCount = (order.Where(oc => statusList.Contains(oc.Status)).Count()) })
                                                   .Where(w => statusList.Contains(w.o.round.Status))
                                                   .GroupBy(w => new
                                                   {
                                                       w.o.round.Id,
                                                       w.o.wine.Name,
                                                       w.o.wine.Type,
                                                       w.o.wine.Store,
                                                       w.o.wine.Price,
                                                       w.o.round.Date,
                                                       w.o.round.Status,
                                                       w.orderCount
                                                   })
                                                   .Select(w => new RoundListItem
                                                   {
                                                       RoundId = w.Key.Id,
                                                       WineName = w.Key.Name,
                                                       WineType = w.Key.Type,
                                                       Store = w.Key.Store,
                                                       WinePrice = w.Key.Price,
                                                       RoundDate = w.Key.Date,
                                                       RoundStatus = w.Key.Status == "A" ? "Aktiv" : (w.Key.Status == "C" ? "Afsluttet" : null),
                                                       OrdersCount = w.Key.orderCount
                                                   }).ToList();
            return roundListItemList;
        }

        public Wine GetRoundWine(int RoundId)
        {
            Wine wine = wpe.Rounds
                        .Join(wpe.Wines, r => r.WineId, w => w.Id, (r, w) => new { r, w })
                        .Where(ws => ws.r.Id == RoundId)
                        .Select(w => new Wine
                        {
                            Id = w.w.Id,
                            Type = w.w.Type,
                            Name = w.w.Name,
                            Store = w.w.Store,
                            Price = w.w.Price
                        }).FirstOrDefault();

            return wine;
        }
        public Rounds GetRound(int RoundId)
        {
            Rounds round = wpe.Rounds.Where(r => r.Id == RoundId).FirstOrDefault();

            return round;
        }

        public decimal GetRoundCostPerOrder(int RoundId)
        {
            var orderCost = wpe.Rounds
                                   .GroupJoin(wpe.Orders,
                                     round => round.Id,
                                     order => order.RoundId,
                                     (round, order) => new { round, orderCount = (order.Count()) })
                                   .Where(ro => ro.round.Id == RoundId)
                                   .Select(x => new
                                   {
                                     OrderCount = x.orderCount > 0 ? x.orderCount : 0,
                                     RoundCost = x.round.Cost,
                                   }).FirstOrDefault();

            return ((decimal)orderCost.RoundCost / orderCost.OrderCount);
        }
    }
}
