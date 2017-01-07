using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WinePusher.Models;

namespace WinePusher.BusinessLogic
{
    class OrderHandler
    {
        WinePusherDBEntities wpe = new WinePusherDBEntities();

        public OrderHandler()
        {
        }

        public void UpdateOrder(int OrderId, int Bottles, string Delivered, string Paid)
        {
            Orders order = new Orders();
            order = wpe.Orders.Where(o => o.Id == OrderId).SingleOrDefault();

            order.Bottles = Bottles;
            order.Delivered = Delivered;
            order.Paid = Paid;

            wpe.Entry(order).State = EntityState.Modified;

            try
            {
                wpe.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateOrder(int OrderId, string Status)
        {
            Orders order = new Orders();
            order = wpe.Orders.Where(o => o.Id == OrderId).SingleOrDefault();

            order.Status = Status;

            wpe.Entry(order).State = EntityState.Modified;

            try
            {
                wpe.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateOrder(int RoundId, int MemberId, int Bottles, string Delivered, string Paid, string Status)
        {
            Orders order = new Orders();

            order.RoundId = RoundId;
            order.MemberId = MemberId;
            order.Bottles = Bottles;
            order.Delivered = Delivered;
            order.Paid = Paid;
            order.Status = Status;
            order.Date = DateTime.Now;

            try
            {
                wpe.Orders.Add(order);
                wpe.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderListItem> ListActiveOrders(int RoundId)
        {
            var statusList = new[] { "A", "B", "C" };

            List<OrderListItem> orderListItemList = wpe.Orders
                                                   .Join(wpe.Rounds,
                                                      o => o.RoundId,
                                                      r => r.Id,
                                                      (o, r) => new { o, r })
                                                   .Join(wpe.Wines,
                                                      ro => ro.r.WineId,
                                                      w => w.Id,
                                                      (ro, w) => new { ro, w })
                                                   .Join(wpe.Members,
                                                      row => row.ro.o.MemberId,
                                                      m => m.Id,
                                                   (row, m) => new { row, m })
                                                   .Where(rowm => rowm.row.ro.r.Id == RoundId && statusList.Contains(rowm.row.ro.o.Status))
                                                   .Select(rowmw => new OrderListItem
                                                   {
                                                       OrderId = rowmw.row.ro.o.Id,
                                                       MemberName = rowmw.m.Name,
                                                       OrderDate = rowmw.row.ro.o.Date,
                                                       Bottles = (int)rowmw.row.ro.o.Bottles,
                                                       TotalAmount = (decimal)rowmw.row.w.Price * (decimal)rowmw.row.ro.o.Bottles,
                                                       Delivered = rowmw.row.ro.o.Delivered,
                                                       Paid = rowmw.row.ro.o.Paid,
                                                   }).ToList();


            int numberOfOrders = orderListItemList.Count();
            decimal roundCost = Convert.ToDecimal(wpe.Rounds.Where(r => r.Id == RoundId).FirstOrDefault().Cost);

            foreach (OrderListItem order in orderListItemList)
            {
                order.TotalAmount = (decimal)order.TotalAmount + (roundCost / numberOfOrders); 
            }


            return orderListItemList;
        }
        public Order GetOrder(int OrderId)
        {
            Order order = wpe.Orders
                                     .Join(wpe.Rounds,
                                                      o => o.RoundId,
                                                      r => r.Id,
                                                      (o, r) => new { o, r })
                                                   .Join(wpe.Wines,
                                                      ro => ro.r.WineId,
                                                      w => w.Id,
                                                      (ro, w) => new { ro, w })
                                                   .Join(wpe.Members,
                                                      row => row.ro.o.MemberId,
                                                      m => m.Id,
                                                   (row, m) => new { row, m })
                                                   .Where(rowm => rowm.row.ro.o.Id == OrderId)
                                                   .Select(rowmw => new Order
                                                   {
                                                       OrderId = rowmw.row.ro.o.Id,
                                                       OrderDate = rowmw.row.ro.o.Date,
                                                       RoundId = rowmw.row.ro.r.Id,
                                                       MemberName = rowmw.m.Name,
                                                       WineName = rowmw.row.w.Name,
                                                       WineType = rowmw.row.w.Type,
                                                       WinePrice = (decimal)(rowmw.row.w.Price),
                                                       Bottles = (int)(rowmw.row.ro.o.Bottles),
                                                       OrderAmount = (decimal)rowmw.row.w.Price * (decimal)rowmw.row.ro.o.Bottles,
                                                       Delivered = rowmw.row.ro.o.Delivered,
                                                       Paid = rowmw.row.ro.o.Paid,
                                                   }).FirstOrDefault();
            return order;
        }
    }
}
