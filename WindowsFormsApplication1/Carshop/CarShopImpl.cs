using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carshop.Carshop;

namespace Carshop.Carshop
{
    public class CarShopImpl : CarShop
    {
        private IList<Car> cars;
        private Storehouse storehouse;

        public CarShopImpl(IList<Car> cars, Storehouse storehouse)
        {
            this.cars = cars;
            this.storehouse = storehouse;
            
            foreach (Car c in cars)
            {
                Console.WriteLine(c.ToString());
            }

            foreach (Car.Part p in storehouse.getFilteredParts(""))
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
