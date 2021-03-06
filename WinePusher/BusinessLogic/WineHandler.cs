﻿using System;
using System.Data.Entity;
using System.Linq;

namespace WinePusher.BusinessLogic
{
    class WineHandler
    {
        WinePusherDBEntities wpe = new WinePusherDBEntities();

        public WineHandler()
        {
        }

        public int CreateWine(string Type, string Name, decimal Price, string Store, string Url)
        {
            Wines wine = new Wines();
            wine.Type = Type;
            wine.Name = Name;
            wine.Price = Price;
            wine.Store = Store;
            wine.Url = Url;

            try
            {
                wpe.Wines.Add(wine);
                wpe.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wine.Id;
        }
        public void UpdateWine(int WineId, string Type, string Name, string Store, string Url, decimal Price)
        {
            Wines wine = new Wines();
            wine = wpe.Wines.Where(w => w.Id == WineId).SingleOrDefault();

            wine.Type = Type;
            wine.Name = Name;
            wine.Price = Price;
            wine.Store = Store;
            wine.Url = Url;

            wpe.Entry(wine).State = EntityState.Modified;

            try
            {
                wpe.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
