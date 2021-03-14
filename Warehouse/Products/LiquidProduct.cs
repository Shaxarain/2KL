using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class LiquidProduct : IProduct
    {
        public string name { get; set; }
        public string type { get; set; } = "liquid";
        public string SKU { get; set; }
        public string description { get; set; }
        public int price { get; set; }

        public LiquidProduct (string a, string b, int c) { name = a; SKU = b; price = c; }
    }
}
