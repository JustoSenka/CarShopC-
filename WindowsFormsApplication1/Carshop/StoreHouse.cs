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

        public IEnumerable<Car.Part> getAllParts()
        {
            return parts.AsEnumerable();
        }

        public IEnumerable<Car.Part> getFilteredParts(string regex)
        {
            if (regex.Equals(""))
            {
                return this.getAllParts();
            }

            ISet<Car.Part> filteredParts = new HashSet<Car.Part>();
            foreach (Car.Part p in parts)
            {
                bool add = true;
                foreach (string word in regex.Split(new char[]{' '}))
                {
                    if (!p.getNameForRegexSearch().ToLower().Contains(word.ToLower()))
                    {
                        add = false;
                    }
                }
                if (add) filteredParts.Add(p);
            }

            return filteredParts.AsEnumerable();
        }
    }
}
