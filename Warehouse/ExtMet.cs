using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace Warehouse.Products
{
    public static class ExtMet
    {
        public static string NameSKU(this IProduct a)
        {
            return $"Product {a.name} SKU = {a.SKU}";
        }
        public static List<IProduct> ProdofTwo(this Warehouse a, Warehouse b)
        {
            IEnumerable<IProduct> match = a.products.Union(b.products); 
            return match.ToList();
        }
        public static string HalfofProd(this Warehouse a, Warehouse b, IProduct c)
        {
            foreach (IProduct j in b.products)
            {
                if(j.SKU == c.SKU && j.quantity > 0)
                {
                    return "This product is already in warehouse";
                }
            }
            foreach (IProduct i in a.products)
            {
                if (i.SKU == c.SKU && i.quantity > 1)
                {
                    int half = i.quantity/2;
                    i.quantity -= half;
                    b.Adding(c, half);
                    return $"Half of {c.name} was migrate";
                }
            }
            return "Half of product wasn't migrate.";
        }
    }
}
