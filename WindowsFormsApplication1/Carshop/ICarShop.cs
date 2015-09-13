using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Carshop
{
    public interface ICarShop
    {
        IList<Object> GetFilteredParts(string regex);
        IList<Object> GetShopCartList();

        void AddToShoppingCart(Object part);
        void RemoveFromShoppingCart(Object part);

        int GetTotalCost();
    }
}
