using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    interface IProduct : ICloneable
    {
        string name { get; set; }
        string type { get; set;}
        string SKU { get; set; }
        string description { get; set; }
        int price { get; set; }
        int quantity { get; set; }
    }
}
