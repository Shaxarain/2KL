using System;
using System.Collections;
using Warehouse.Products;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace Warehouse
{
    class Program
    {
        private static void DisplayMessage(object sengder, AddProdEventArgs ea)
        {
            Console.WriteLine(ea.AddProdMes);
        }
        public static void CSVsaving(Warehouse a, string b, string c)
        {
            if (Directory.Exists(b))
            {
                int count = 1;
                using (StreamWriter sw = new StreamWriter(c, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"count;name;type;SKU;description;price;qiantity;");
                }
                foreach (IProduct pr in a.products)
                {
                    using (StreamWriter sw = new StreamWriter(c, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine($"{count};{pr.name};{pr.type};{pr.SKU};{pr.description};{pr.price};{pr.quantity};");
                    }
                    count++;
                }
            }
            else
            {
                Console.WriteLine("File not saved");
            }
        }
        static void Main(string[] args)
        {
            Catalog Cat = Catalog.getInstance();

            Employee Archi = new Employee("Archibald", "Dog");
            Employee Ch = new Employee("Cheburek", "Cooker");

            Address sc = new Address("Somewhere", "Somestreet", 55);
            Address ololo = new Address("Ololand", "Olostreet", 01010);
            Address Dudley = new Address("Surrey", "Privet Drive", 4);
            Address Neverhood = new Address("Neverland", "Neverstreet", 10);

            Warehouse HouseofLiquid = new Warehouse(sc, 500, true);
            HouseofLiquid.AdProdNotify += DisplayMessage;
            HouseofLiquid.UncorAddNotify += DisplayMessage;
            Warehouse HouseofObject = new Warehouse(ololo, 1000, false);
            HouseofObject.AdProdNotify += DisplayMessage;
            Warehouse HouseofGrit = new Warehouse(Dudley, 333, false);
            HouseofGrit.AdProdNotify += DisplayMessage;
            Warehouse HouseofAll = new Warehouse(Neverhood, 100, false);

            HouseofLiquid.Adding(Cat.Buying("010"), 1);
            HouseofLiquid.Adding(Cat.Buying("011"), 1);
            HouseofLiquid.Adding(Cat.Buying("000"), 5);
            HouseofLiquid.Adding(Cat.Buying("000"), 10);

            HouseofGrit.Adding(Cat.Buying("100"), 5);
            HouseofGrit.Adding(Cat.Buying("101"), 228);

            HouseofObject.Adding(Cat.Buying("200"), 8);
            HouseofObject.Adding(Cat.Buying("201"), 3);

            HouseofAll.Adding(Cat.Buying("000"), 10);
            HouseofAll.Adding(Cat.Buying("010"), 10);
            HouseofAll.Adding(Cat.Buying("011"), 10);
            HouseofAll.Adding(Cat.Buying("100"), 10);
            HouseofAll.Adding(Cat.Buying("101"), 10);
            HouseofAll.Adding(Cat.Buying("200"), 10);
            HouseofAll.Adding(Cat.Buying("201"), 10);

            string EmpofWare = HouseofObject.Addresp_emp(Archi);
            string SKUofProd = HouseofLiquid.SKUfinder("011");
            Console.WriteLine(SKUofProd);

            //Price of all Warehouses
            int FinPrice = HouseofLiquid.Totalprice();
            FinPrice += HouseofGrit.Totalprice();
            FinPrice += HouseofObject.Totalprice();
            Console.WriteLine(FinPrice);

            string Mov = HouseofLiquid.Move(Cat.Buying("000"), HouseofObject, 4);
            Console.WriteLine(Mov);

            string NameSKUtest = (Cat.Buying("200")).NameSKU();
            Console.WriteLine(NameSKUtest);

            HouseofObject.Adding(Cat.Buying("010"), 7);
            List<IProduct> matches = HouseofLiquid.ProdofTwo(HouseofObject);
            Console.WriteLine("Products in two warehouses:");
            foreach(IProduct i in matches)
            {
                Console.WriteLine(i.name);
            }

            string Reshalf = HouseofGrit.HalfofProd(HouseofAll, Cat.Buying("101"));
            Console.WriteLine(Reshalf);
            HouseofAll.Move(Cat.Buying("101"), HouseofGrit, 10);
            Reshalf = HouseofGrit.HalfofProd(HouseofAll, Cat.Buying("101"));
            Console.WriteLine(Reshalf);
            HouseofGrit.Adding(Cat.Buying("101"), 0);

            List<IProduct>Morethree = HouseofAll.MoreThree();
            Console.WriteLine("More than three products:");
            foreach (IProduct i in Morethree)
            {
                Console.WriteLine(i.name + " " + i.quantity);
            }
            List<string> Universal = HouseofAll.Unicum();
            Console.WriteLine("Universal names...");
            foreach (string i in Universal)
            {
                Console.WriteLine(i);
            }
            Warehouse test = new Warehouse(sc, 2, false);
            /*test.Adding(cocaine, 10);*/
            // ???
            List<string> NG = HouseofLiquid.NotGrid(HouseofGrit, test, HouseofObject);
            Console.WriteLine("Warehouses without grit products");
            foreach (string w in NG)
            {
                Console.WriteLine(w);
            }

            string dir = @"D";
            string road = @"D:Products.csv";
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            dirInfo.Create();
            CSVsaving(HouseofAll, dir, road);
            CSVsaving(HouseofLiquid, dir, road);
            /*            try
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
                        }*/
        }
    }
}
