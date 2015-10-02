using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Carshop
{
    public class ShoppingCart : IEnumerable<Car.Part>
    {
        private IList<Car.Part> parts;

        public ShoppingCart()
        {
            parts = new List<Car.Part>();
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

        public IList<string> SellCartAndGetReceipt()
        {
            IList<string> receipt = new List<string>();

            receipt.Add("Log date: " + DateTime.Now.ToString());
            receipt.AddSeparator();

            foreach (Car.Part part in parts)
            {
                receipt.AddAligned(part.GetNameAndPrice().Name, part.GetNameAndPrice().Price);
            }

            receipt.With(x =>
            {
                x.AddSeparator();
                x.AddAligned("Total cost: ", this.GetTotalCost());
                x.AddSeparator();
                x.Add("");
            });

            parts.Clear();

            return receipt;
        }

        public IEnumerator<Car.Part> GetEnumerator()
        {
            foreach (var t in parts)
            {
                if (t == null)
                {
                    break;
                }
                yield return t;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
