using System;
using System.Collections;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Archi = new Employee("Arthur", "boss");

            Warehouse HouseofLiquid = new Warehouse("Privet Drive", 500, true);
            Warehouse HouseofObject = new Warehouse("Forest", 1000, false);
            Warehouse HouseofGrit = new Warehouse("Sandbox", 333, false);

            IProduct poison = new LiquidProduct("poison", "000", 666);
            IProduct sugar = new GritProduct("sygar", "100", 500);

            string AdResult1 = HouseofLiquid.Adding(sugar);
            Console.WriteLine(AdResult1);

            string AdResult2 = HouseofObject.Addresp_emp(Archi);
            Console.WriteLine(AdResult2);

            /*foreach (IProduct lel in HouseofLiquid.products)
            {
                Console.WriteLine(lel.name);
            }*/
        }
    }
}
