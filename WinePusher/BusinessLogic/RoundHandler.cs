using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            round.Cost = Cost;
            round.Status = Status;

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
        public void UpdateRound(int RoundId, decimal Cost, string Status)
        {
            Rounds round = new Rounds();
            round = wpe.Rounds.Where(r => r.Id == RoundId).SingleOrDefault();

            round.Cost = Cost;
            round.Status = Status;

            wpe.Entry(round).State = EntityState.Modified;

            try
            {
                wpe.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateRound(int RoundId, string Status)
        {
            Rounds round = new Rounds();
            round = wpe.Rounds.Where(r => r.Id == RoundId).SingleOrDefault();

            round.Status = Status;

            wpe.Entry(round).State = EntityState.Modified;

            try
            {
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
                                                       w.o.wine.Url,
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
                                                       WineUrl = w.Key.Url,
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
        public Round GetRound(int RoundId)
        {
            Round round = wpe.Rounds
                .Join(wpe.Wines, r => r.WineId, w => w.Id, (r, w) => new { r, w })
                        .Where(ws => ws.r.Id == RoundId)
                        .Select(rw => new Round
                        {
                            WineId = rw.w.Id,
                            WineType = rw.w.Type,
                            WineName = rw.w.Name,
                            WinePrice = (decimal)rw.w.Price,
                            Store = rw.w.Store,
                            Url = rw.w.Url,
                            Cost = (decimal)rw.r.Cost,
                            Status = rw.r.Status,
                        }).FirstOrDefault();

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
