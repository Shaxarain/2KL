using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Warehouse
{
    public static class Reports
    {
        public static async void MoreThreeAsync(Warehouse a)
        {
            await Task.Run(() => MoreThree(a));
        }
        public static void MoreThree(this Warehouse a)
        {
            IEnumerable<IProduct> MT = from pr in a.products
                                     where pr.quantity > 3
                                     orderby pr.quantity
                                     select pr;
            Console.WriteLine($"More than 3 products on {a.address.city}:");
            foreach (IProduct i in MT)
            {
                Console.WriteLine($"{i.name} = {i.quantity}");
            }
        }
        public static async void UnicumAsync(Warehouse a)
        {
            await Task.Run(() => Unicum(a));
        }
        public static void Unicum(this Warehouse a)
        {
            IEnumerable<string> prod = from pr in a.products
                                       where pr.quantity == 1
                                       select pr.name;
            Console.WriteLine($"Universal names on {a.address.city}:");
            foreach (string i in prod)
            {
                Console.WriteLine(i);
            }
        }
        public static async void MostAsync(Warehouse a)
        {
            await Task.Run(() => Most(a));
        }
        public static void Most(this Warehouse a)
        {
            IEnumerable<IProduct> copy = a.products.OrderByDescending(i => i.quantity);
            IEnumerable<IProduct> MostHave = copy.Take(3);
            Console.WriteLine($"Most products in {a.address.city}:");
            foreach (IProduct i in MostHave)
            {
                Console.WriteLine($"{i.name} = {i.quantity}");
            }
        }
        public static async void NotGridAsync(Warehouse a, Warehouse b, Warehouse c)
        {
            await Task.Run(() => NotGrid(a, b, c));
        }
        public static void NotGrid(this Warehouse a, Warehouse b, Warehouse c)
        {
            List<Warehouse> warehouses = new List<Warehouse> {a, b, c};
            IEnumerable<Warehouse> NG = from ws in warehouses
                                        from pr in ws.products
                                        where pr.type != "grit"
                                        select ws;
            Console.WriteLine("Warehouses without grit products:");
            foreach (Warehouse i in NG.Distinct())
            {
                Console.WriteLine(i.address.city);
            }
            /*var selectedStorages = warehouses.Where(p => p.products.Where(a => a.type != "grit").Any()).ToList();
            selectedStorages = selectedStorages.ToList();
            var NGW = from t in selectedStorages
                      select t.address.city;*/
            /*IEnumerable<string> NGW = from ws in warehouses
                                      from pr in ws.products
                                      where pr.type != "grit"
                                      select ws.address.city;*/
        }
    }
}
