using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Carshop
{
    public class Car : IComparable<Car>
    {
        //#warning Accessability issue on parts : public for linq.
        private IList<Part> parts;
        public IList<Part> Parts
        {
            get
            {
                return parts;
            }
            set
            {
                foreach (Part p in value)
                {
                    p.originalCar = this;
                }
                parts = value;
            }
        }
        public int id { get; private set; }
        public string manufacturer { get; private set; }
        public string model { get; private set; }
        public int year { get; private set; }

        public Car(int id, string manufacturer, string model, int year)
        {
            this.id = id;
            this.manufacturer = manufacturer;
            this.model = model;
            this.year = year;
        }

        public override string ToString()
        {
            string str = "Car: id=" + this.id + ", " + this.manufacturer + " " + this.model + ":";
            foreach (Part p in parts)
            {
                str += "\n\r  " + p.ToString();
            }
            return str;
        }

        public int CompareTo(Car other)
        {
            int a;
            if ((a = this.manufacturer.CompareTo(other.manufacturer)) != 0) return a;
            else if ((a = this.model.CompareTo(other.model)) != 0) return a;
            else return this.year.CompareTo(other.year);
        }

        public class Part : IEquatable<Car.Part>
        {
            public int id { get; private set; }
            public string name { get; private set; }
            public int price { get; private set; }
           
            //#warning Accessability issue on originalCar : setter is public.
            public Car originalCar { get; set; }

            public Part(Part part) : this(part.id, part.name, part.price) 
            {
                this.originalCar = part.originalCar;   
            }
            public Part(int id, string name, int price)
            {
                this.id = id;
                this.name = name;
                this.price = price;
            }

            public override string ToString()
            {
                return "Part: id=" + this.id + ", name=" + this.name + ", price=" + 
                       this.price + ", originalCarId=" + originalCar.id;
            }

            public bool Equals(Car.Part part)
            {
                if (this.name == part.name &&
                    this.price == part.price &&
                    this.originalCar == part.originalCar &&
                    this.id == part.id)
                {
                    return true;
                }
                else
                    return false;
            }

            public struct NameAndPrice
            {
                public string Name { get; set; }
                public string Price { get; set; }
            }
        }
    }
}
