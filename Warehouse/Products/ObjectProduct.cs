using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class ObjectProduct: IProduct
    {
        public string name { get; set; }
        public string type { get; set; } = "object";
        public string SKU { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public ObjectProduct(string a, string b, int c) { name = a; SKU = b; price = c; }
    }
}
