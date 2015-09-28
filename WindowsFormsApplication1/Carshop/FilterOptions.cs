using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Carshop
{
    [Flags]
    public enum FilterOptions
    {
        None = 0,
        HideYear = 1,
        HideModel = 2
    }
}
