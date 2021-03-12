using System;
using System.Collections;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Archi = new Employee("Archibald", "Dog");
            Employee Ch = new Employee("Cheburek", "Cooker");

            Warehouse HouseofLiquid = new Warehouse("Privet Drive", 500, true);
            Warehouse HouseofObject = new Warehouse("Forest", 1000, false);
            Warehouse HouseofGrit = new Warehouse("Sandbox", 333, false);

            IProduct poison = new LiquidProduct("poison", "000", 666);
            IProduct aj = new LiquidProduct("apple juice", "010", 560);
            IProduct bj = new LiquidProduct("berry juice", "011", 600);

            IProduct sugar = new GritProduct("sygar", "100", 500);
            IProduct cocaine = new GritProduct("coconut flakes", "101", 3000);
            cocaine.description = "Not a cocaine";

            IProduct heart = new ObjectProduct("heart of human", "200", 5000);
            IProduct mouse = new ObjectProduct("dead mouse","201", 0);

            //Check Adding
            string AdResult1 = HouseofLiquid.Adding(sugar);
            HouseofLiquid.Adding(poison);
            HouseofLiquid.Adding(poison); //more product...
            HouseofLiquid.Adding(aj);
            HouseofLiquid.Adding(bj);

            HouseofGrit.Adding(sugar);
            HouseofGrit.Adding(cocaine);

            HouseofObject.Adding(heart);
            HouseofObject.Adding(mouse);

            Console.WriteLine(AdResult1);

            //Check... this
            string AdResult2 = HouseofObject.Addresp_emp(Archi);
            Console.WriteLine(AdResult2);
            //Check
            string AdResult3 = HouseofLiquid.SKUfinder("011");
            Console.WriteLine(AdResult3);
            
            //Price of all Warehouses
            int AdResult4 = HouseofLiquid.Totalprice();
            AdResult4 += HouseofGrit.Totalprice();
            AdResult4 += HouseofObject.Totalprice();
            int hoo_price = HouseofObject.Totalprice();
            Console.WriteLine(hoo_price);
            Console.WriteLine(AdResult4);

            //Check moving
            string AdResult5 = HouseofLiquid.Move(poison, HouseofObject);
            Console.WriteLine(AdResult5);
            hoo_price = HouseofObject.Totalprice();
            Console.WriteLine(hoo_price);
        }
    }
}
