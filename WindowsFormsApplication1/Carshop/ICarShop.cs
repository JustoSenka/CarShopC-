using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Carshop
{
    public interface ICarShop
    {
        IEnumerable<Object> GetFilteredParts(string regex = "", FilterOptions filterOptions = FilterOptions.None);
        IEnumerable<Object> GetShopCartList();

        void AddToShoppingCart(Object part);
        void RemoveFromShoppingCart(Object part);

        int GetTotalCost();

        void SellCart();
    }
}
