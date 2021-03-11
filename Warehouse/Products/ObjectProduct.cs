using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Products
{
    class ObjectProduct: IProduct
    {
        public string name { get; set; }
        public string type { get; set; } = "object";
        public string SKU { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }
}
