using System;
using System.Collections;
using Warehouse.Products;

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

            string EmpofWare = HouseofObject.Addresp_emp(Archi);
            string SKUofProd = HouseofLiquid.SKUfinder("011");
            Console.WriteLine(SKUofProd);

            //Price of all Warehouses
            int FinPrice = HouseofLiquid.Totalprice();
            FinPrice += HouseofGrit.Totalprice();
            FinPrice += HouseofObject.Totalprice();
            int hoo_price = HouseofObject.Totalprice();
            Console.WriteLine(hoo_price);
            Console.WriteLine(FinPrice);

            string Mov = HouseofLiquid.Move(poison, HouseofObject, 4);
            Console.WriteLine(Mov);

            hoo_price = HouseofObject.Totalprice();
            Console.WriteLine(hoo_price);
            Console.WriteLine("test");

            string NameSKUtest = heart.NameSKU();
            Console.WriteLine(NameSKUtest);

            HouseofObject.Adding(aj, 7);
            ArrayList matches = HouseofLiquid.ProdofTwo(HouseofObject);
            Console.WriteLine("Products in two warehouses:");
            foreach(IProduct i in matches)
            {
                Console.WriteLine(i.name);
            }

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
