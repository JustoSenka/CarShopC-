﻿using Carshop.Carshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

namespace Carshop.Carshop
{
    public class CarShopFactory
    {
        public static CarShop getCarShop()
        {
            IList<Car> cars = XmlReader.GetAllCars(Properties.Resources.Cars);
            IList<Car.Part> parts = XmlReader.GetStorehouseParts(Properties.Resources.Storehouse, cars);

            return new CarShopImpl(cars, new Storehouse(parts));
        }
    }
}