using Carshop.Carshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

namespace Carshop.Carshop
{
    public static class CarShopFactory
    {
        public static ICarShop GetCarShop(string Cars, string Storehouse)
        {

            IList<Car> cars = XmlReader.GetAllCars(Cars);
            IList<Car.Part> parts = XmlReader.GetStorehouseParts(Storehouse, cars);

            return new CarShop(cars, new Storehouse(parts));
        }
    }
}
