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

        public IList<Object> GetFilteredParts(string regex)
        {
            IList<Object> list = new List<Object>();
            foreach (Car.Part p in storehouse.GetFilteredParts(regex))
            {
                list.Add(p.GetFullName());
            }
            return list.AsEnumerable().Distinct().ToList(); // No duplicates
        }

        public IList<Object> GetShopCartList()
        {
            IList<Object> list = new List<Object>();
            foreach (Car.Part p in shoppingCart.GetAllParts())
            {
                list.Add(p.GetFullName());
            }
            return list;
        }

        public void AddToShoppingCart(Object part)
        {
            foreach (Car.Part p in storehouse.GetAllParts())
            {
                if (p.GetFullName().Equals(part))
                {
                    storehouse.RemovePart(p);
                    shoppingCart.AddPart(p);
                    return;
                }
            }
        }

        public void RemoveFromShoppingCart(Object part)
        {
            foreach (Car.Part p in shoppingCart.GetAllParts())
            {
                if (p.GetFullName().Equals(part))
                {
                    storehouse.AddPart(p);
                    shoppingCart.RemovePart(p);
                    return;
                }
            }
        }

        public int GetTotalCost()
        {
            return shoppingCart.GetTotalCost();
        }
    }
}
