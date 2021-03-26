using System;
using System.Collections.Generic;
using System.Collections;
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
        public static List<string> Unicum(this Warehouse a)
        {
            IEnumerable<string> prod = from pr in a.products
                                       select pr.name;
            return prod.ToList();
        }
        public static List<IProduct> Most(this Warehouse a)
        {
            IEnumerable<IProduct> copy = a.products.OrderByDescending(i => i.quantity);
            IEnumerable<IProduct> MostHave = copy.Take(3);
            return MostHave.ToList();
        }
        public static List<string> NotGrid(this Warehouse a, Warehouse b, Warehouse c, Warehouse d)
        {
            List<Warehouse> warehouses = new List<Warehouse> { a, b, c, d };
            var selectedStorages = warehouses.Where(p => p.products.Where(a => a.type != "grit").Any()).ToList();
            selectedStorages = selectedStorages.ToList();
            var NGW = from t in selectedStorages
                      select t.address.city;
            /*IEnumerable<string> NGW = from ws in warehouses
                                      from pr in ws.products
                                      where pr.type != "grit"
                                      select ws.address.city;*/
            NGW.Distinct();
            return NGW.ToList();
        }
    }
}
