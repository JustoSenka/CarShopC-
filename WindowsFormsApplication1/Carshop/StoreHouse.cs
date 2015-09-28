using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carshop.Carshop;

namespace Carshop.Carshop
{
    public class Storehouse
    {
        private IList<Car.Part> parts;

        public Storehouse(IList<Car.Part> parts)
        {
            this.parts = parts;
        }

        public IList<Car.Part> GetFilteredParts(string regex = "")
        {
            if (regex.Equals(""))
            {
                return this.parts;
            }

            ISet<Car.Part> filteredParts = new HashSet<Car.Part>();
            foreach (Car.Part part in parts)
            {
                bool add = true;
                foreach (string word in regex.Split(new char[]{' '}))
                {
                    if (!part.GetNameForRegexSearch().ToLower().Contains(word.ToLower()))
                    {
                        add = false;
                    }
                }
                if (add) filteredParts.Add(part);
            }

            return filteredParts.ToList();
        }

        public void RemovePart(Car.Part part)
        {
            parts.Remove(part);
        }

        public void AddPart(Car.Part part)
        {
            parts.Add(part);
        }
    }
}
