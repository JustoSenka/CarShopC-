using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Carshop.Carshop
{
    public static class XmlReader
    {
        public static IList<Car> GetAllCars(string xmlResource)
        {
            XElement xml = XElement.Parse(xmlResource);
            IList<Car> cars =
            (
                from e in xml.Elements("Car")
                select new Car
                (
                    (int)Int32.Parse(e.Attribute("id").Value),
                    (string)e.Attribute("manufacturer").Value,
                    (string)e.Attribute("model").Value,
                    (int)Int32.Parse(e.Attribute("year").Value)
                )
                {
                    Parts =
                    (
                        from p in e.Elements("Parts").Elements("Part")
                        select new Car.Part
                        (
                            (int)Int32.Parse(p.Attribute("id").Value),
                            (string)p.Attribute("name").Value,
                            (int)Int32.Parse(p.Attribute("price").Value)
                        )
                    ).ToList()
                }
             ).ToList();

            return cars;
        }

        public static IList<Car.Part> GetStorehouseParts(string xmlResource, IList<Car> cars)
        {
            XElement xml = XElement.Parse(xmlResource);
            IList<Car.Part> parts =
            (
                from e in xml.Elements("Parts").Elements("Part")
                select new Car.Part
                (
                    cars.ElementAt(Int32.Parse(e.Attribute("car").Value) - 1).Parts.ElementAt(Int32.Parse(e.Attribute("part").Value) - 1)
                )
             ).ToList();

            return parts;
        }
    }
}
