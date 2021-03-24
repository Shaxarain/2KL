using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Warehouse
{
    public static class Reports
    {
        public static List<IProduct> MoreThree(this Warehouse a)
        {
            IEnumerable<IProduct> MT = (a.products).Where(i => i.quantity > 3);
            MT = MT.OrderBy(j => j.quantity);
            return MT.ToList();
        }
        public static List<IProduct> Unicum(this Warehouse a, Warehouse b)
        {
            IEnumerable<IProduct> Uni = (a.products).Union(b.products);
            return Uni.ToList();
        }
    }
}
