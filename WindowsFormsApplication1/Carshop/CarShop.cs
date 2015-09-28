using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carshop.Carshop;

namespace Carshop.Carshop
{
    public class CarShop : ICarShop
    {
        private IList<Car> cars;
        private Storehouse storehouse;
        private ShoppingCart shoppingCart;

        public CarShop(IList<Car> cars, Storehouse storehouse)
        {
            this.cars = cars;
            this.storehouse = storehouse;
            this.shoppingCart = new ShoppingCart();
        }

        public IEnumerable<Object> GetFilteredParts(string regex = "", FilterOptions filterOptions = FilterOptions.None)
        {
            IList<Object> list = new List<Object>();
            foreach (Car.Part p in storehouse.GetFilteredParts(regex))
            {
                list.Add(p.GetFullName(filterOptions));
            }
            return list.AsEnumerable().Distinct(); // No duplicates
        }

        public IEnumerable<Object> GetShopCartList()
        {
            IList<Object> list = new List<Object>();
            foreach (Car.Part p in shoppingCart)
            {
                list.Add(p.GetFullName());
            }
            return list.AsEnumerable();
        }

        public void AddToShoppingCart(Object part)
        {
            foreach (Car.Part p in storehouse.GetFilteredParts())
            {
                if (p.GetFullName().Equals(part))
                {
                    storehouse.RemovePart(part: p);
                    shoppingCart.AddPart(part: p);
                    return;
                }
            }
        }

        public void RemoveFromShoppingCart(Object part)
        {
            using (IEnumerator<Car.Part> e = shoppingCart.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (e.Current.GetFullName().Equals(part))
                    {
                        storehouse.AddPart(e.Current);
                        shoppingCart.RemovePart(e.Current);
                        return;
                    }
                }
            }
        }

        public int GetTotalCost()
        {
            return shoppingCart.GetTotalCost();
        }

        public void SellCart()
        {
            IList<string> receipt = shoppingCart.SellCartAndGetReceipt();
            Logger.LogToFile("Log.txt", receipt);
        }
    }
}
