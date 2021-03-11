using System;
using System.Collections;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse HouseofLiquid = new Warehouse("Privet Drive", 500, true);
            Warehouse HouseofObject = new Warehouse("Forest", 1000, false);
            Warehouse HouseofGrit = new Warehouse("Sandbox", 333, false);
            IProduct poison = new LiquidProduct("poison", "000", 13);
            string AdResult1 = HouseofLiquid.Adding(poison);
            Console.WriteLine(AdResult1);
        }
    }
}
