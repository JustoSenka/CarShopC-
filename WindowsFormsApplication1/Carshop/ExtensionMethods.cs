using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Carshop
{
    public static class ExtensionMethods
    {
        public static string GetNameForRegexSearch(this Car.Part part)
        {
            return part.name + " " + part.originalCar.manufacturer + " " +
                   part.originalCar.model + " " + part.originalCar.year;
        }

        public static string GetFullName(this Car.Part part, FilterOptions filterOptions = FilterOptions.None)
        {
            String full = part.originalCar.manufacturer + " ";

            if (!filterOptions.HasFlag(FilterOptions.HideModel)) full += part.originalCar.model + " ";
            if (!filterOptions.HasFlag(FilterOptions.HideYear)) full += part.originalCar.year + " ";

            full += part.name + " - " + part.price + "$";

            return full;
        }

        public static Car.Part.NameAndPrice GetNameAndPrice(this Car.Part part)
        {
            return new Car.Part.NameAndPrice()
            {
                Name = part.originalCar.manufacturer + " " + part.originalCar.model + " " +
                       part.originalCar.year + " " + part.name,
                Price = part.price.ToString()
            };
        }

        public static void AddSeparator(this IList<string> list)
        {
            list.Add("--------------------------------------------");
        }

        public static void AddAligned<T, E>(this IList<string> list, T t, E e)
        {
            list.Add(String.Format("{0,-35} - {1,5}$", t.ToString(), e.ToString()));
        }

        public static void With<T>(this T obj, Action<T> act) 
        { 
            act(obj); 
        }
    }
}
