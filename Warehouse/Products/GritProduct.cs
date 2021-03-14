using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class GritProduct: IProduct, ICloneable
    {
        public string name { get; set; }
        public string type { get; set; } = "grit";
        public string SKU { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int quantity { get; set; } = 0;
        public GritProduct(string a, string b, int c) { name = a; SKU = b; price = c; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
