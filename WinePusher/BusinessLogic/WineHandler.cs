using System;
using System.Linq;

namespace WinePusher.BusinessLogic
{
    class WineHandler
    {
        WinePusherDBEntities wpe = new WinePusherDBEntities();

        public WineHandler()
        {
        }

        public int CreateWine(string Type, string Name, decimal Price, string Store)
        {
            Wines wine = new Wines();
            wine.Type = Type;
            wine.Name = Name;
            wine.Price = Price;
            wine.Store = Store;

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
    }
}
