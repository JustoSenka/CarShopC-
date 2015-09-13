using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Carshop
{
    public class ShoppingCart
    {
        private IList<Car.Part> parts;

        public ShoppingCart()
        {
            parts = new List<Car.Part>();
        }

        public IList<Car.Part> GetAllParts()
        {
            return parts;
        }

        public void AddPart(Car.Part part)
        {
            parts.Add(part);
        }

        public void RemovePart(Car.Part part)
        {
            parts.Remove(part);
        }

        public int GetTotalCost()
        {
            int totalCost = 0;

            foreach (Car.Part part in parts)
            {
                totalCost += part.price;
            }

            return totalCost;
        }
    }
}
