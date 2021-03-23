using System;
using System.Collections;

namespace Warehouse
{
    class Program
    {
        private static void DisplayMessage(object sengder, AddProdEventArgs ea)
        {
            Console.WriteLine(ea.AddProdMes);
        }
        static void Main(string[] args)
        {
            Employee Archi = new Employee("Archibald", "Dog");
            Employee Ch = new Employee("Cheburek", "Cooker");

            Address sc = new Address("Somewhere", "Somestreet", 55);
            Address ololo = new Address("Ololand", "Olostreet", 01010);
            Address Dudley = new Address("Surrey", "Privet Drive", 4);

            Warehouse HouseofLiquid = new Warehouse(sc, 500, true);
            HouseofLiquid.AdProdNotify += DisplayMessage;
            HouseofLiquid.UncorAddNotify += DisplayMessage;
            Warehouse HouseofObject = new Warehouse(ololo, 1000, false);
            HouseofObject.AdProdNotify += DisplayMessage;
            Warehouse HouseofGrit = new Warehouse(Dudley, 333, false);
            HouseofGrit.AdProdNotify += DisplayMessage;
            IProduct poison = new LiquidProduct("poison", "000", 666);

            IProduct aj = new LiquidProduct("apple juice", "010", 560);
            IProduct bj = new LiquidProduct("berry juice", "011", 600);

            IProduct sugar = new GritProduct("sygar", "100", 500);
            IProduct cocaine = new GritProduct("coconut flakes", "101", 3000);
            cocaine.description = "Not a cocaine";

            IProduct heart = new ObjectProduct("heart of human", "200", 5000);
            IProduct mouse = new ObjectProduct("dead mouse", "201", 0);

            HouseofLiquid.Adding(aj, 1);
            HouseofLiquid.Adding(bj, 1);
            HouseofLiquid.Adding(poison, 5);
            HouseofLiquid.Adding(poison, 10);

            HouseofGrit.Adding(sugar, 5);
            HouseofGrit.Adding(cocaine, 228);

            HouseofObject.Adding(heart, 8);
            HouseofObject.Adding(mouse, 3);

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
            Console.WriteLine("test");

            try
            {
                HouseofLiquid.Adding(sugar, 1);
            }
            catch (Exception opengrit)
            {
                Console.WriteLine("Error! " + opengrit.Message);
            }
            finally
            {
                Console.WriteLine("Test complited");
            }
        }
    }
}
