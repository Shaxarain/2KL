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

            Address sc = new Address("Somewhere", "Somestreet", 55);
            Address ololo = new Address("Ololand", "Olostreet", 01010);
            Address Dudley = new Address("Surrey", "Privet Drive", 4) ;

            Warehouse HouseofLiquid = new Warehouse(sc, 500, true);
            Warehouse HouseofObject = new Warehouse(ololo, 1000, false);
            Warehouse HouseofGrit = new Warehouse(Dudley, 333, false);


            IProduct poison = new LiquidProduct("poison", "000", 666);

            IProduct aj = new LiquidProduct("apple juice", "010", 560);
            IProduct bj = new LiquidProduct("berry juice", "011", 600);

            IProduct sugar = new GritProduct("sygar", "100", 500);
            IProduct cocaine = new GritProduct("coconut flakes", "101", 3000);
            cocaine.description = "Not a cocaine";

            IProduct heart = new ObjectProduct("heart of human", "200", 5000);
            IProduct mouse = new ObjectProduct("dead mouse","201", 0);

            //Check Adding
            string AdResult1 = HouseofLiquid.Adding(sugar, 8);
            string Res0 = HouseofLiquid.Adding(poison, 2);
            Console.WriteLine(Res0);
            string Res1 = HouseofLiquid.Adding(poison, 3); //more product..
            Console.WriteLine(Res1);
            HouseofLiquid.Adding(aj, 1);
            HouseofLiquid.Adding(bj, 1);

            HouseofGrit.Adding(sugar, 5);
            HouseofGrit.Adding(cocaine, 228);

            HouseofObject.Adding(heart, 8);
            HouseofObject.Adding(mouse, 3);

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
            string AdResult5 = HouseofLiquid.Move(poison, HouseofObject, 4);
            Console.WriteLine(AdResult5);
            hoo_price = HouseofObject.Totalprice();
            Console.WriteLine(hoo_price);
        }
    }
}
