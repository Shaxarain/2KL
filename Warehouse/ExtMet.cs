using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Warehouse.Products
{
    public static class ExtMet
    {
        public static string NameSKU(this IProduct a)
        {
            return $"Product {a.name} SKU = {a.SKU}";
        }
        public static ArrayList ProdofTwo(this Warehouse a, Warehouse b)
        {
            ArrayList matches = new ArrayList();
            foreach(IProduct i in a.products)
            {
                if (b.Finder(i.SKU))
                {
                    matches.Add(i);
                }
            }
            return matches;
        }
    }
}
