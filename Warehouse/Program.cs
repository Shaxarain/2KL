using System;
using Warehouse.Products;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using NLog;
using System.Reflection;
using System.Linq;

namespace Warehouse
{
    class Program
    {
        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }
        private static void DisplayMessage(object sengder, AddProdEventArgs ea)
        {
            Console.WriteLine(ea.AddProdMes);
            Logger log = LogManager.GetCurrentClassLogger();
            log.Trace(ea.AddProdMes);
        }
        private static void Dzin(object client, AddProdEventArgs ea)
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
            Employee Kozya = new Employee("Kuzma", "Worker");
            Employee No = new Employee("Eleonora", "Worker");

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
            HouseofAll.AdProdNotify += DisplayMessage;

            string EmpofWare = HouseofAll.Addresp_emp(Archi);
            HouseofAll.Addresp_emp(Archi);
            HouseofLiquid.Addresp_emp(No);
            HouseofGrit.Addresp_emp(Kozya);
            HouseofObject.Addresp_emp(Ch);
            Console.WriteLine(EmpofWare);

            List<Task> Tasks = new List<Task>();

            No.NewTask += Dzin;
            No.ComsForEmp(Cat.Buying("010"), 1);
            No.ComsForEmp(Cat.Buying("011"), 1);
            No.ComsForEmp(Cat.Buying("000"), 5);
            No.ComsForEmp(Cat.Buying("000"), 10);
            Task HoL = new Task(() => No.Plus());
            Tasks.Add(HoL);

            Kozya.NewTask += Dzin;
            Kozya.ComsForEmp(Cat.Buying("100"), 5);
            Kozya.ComsForEmp(Cat.Buying("101"), 228);
            Task HoG = new Task(() => Kozya.Plus());
            Tasks.Add(HoG);

            Ch.NewTask += Dzin;
            Ch.ComsForEmp(Cat.Buying("200"), 8);
            Ch.ComsForEmp(Cat.Buying("201"), 3);
            Task HoO = new Task(() => Ch.Plus());
            Tasks.Add(HoO);

            Archi.NewTask += Dzin;
            Archi.ComsForEmp(Cat.Buying("200"), 10);
            Archi.ComsForEmp(Cat.Buying("000"), 10);
            Archi.ComsForEmp(Cat.Buying("010"), 10);
            Archi.ComsForEmp(Cat.Buying("011"), 10);
            Archi.ComsForEmp(Cat.Buying("100"), 1);
            Archi.ComsForEmp(Cat.Buying("101"), 10);
            Archi.ComsForEmp(Cat.Buying("201"), 10);
            Task HoA = new Task(() => Archi.Plus());
            Tasks.Add(HoA);

            CancellationTokenSource CToken = new CancellationTokenSource();
            CancellationToken token = CToken.Token;

            var Houses = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Start adding tasks? (No for stop)");
                foreach (Task i in Tasks)
                {
                    string ans = Console.ReadLine();
                    if (ans == "No" || ans == "no")
                    {
                        CToken.Cancel();
                    }
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Operation stopped!");
                        return;
                    }
                    var AddTask = Task.Factory.StartNew(() => i.Start(), TaskCreationOptions.AttachedToParent);
                    AddTask.Wait();
                }
            });
            Houses.Wait();

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

            List<IProduct> matches = HouseofLiquid.ProdofTwo(HouseofObject);

            string Reshalf = HouseofGrit.HalfofProd(HouseofAll, Cat.Buying("101"));
            HouseofAll.Move(Cat.Buying("101"), HouseofGrit, 10);
            Reshalf = HouseofGrit.HalfofProd(HouseofAll, Cat.Buying("101"));

            Parallel.Invoke(
                () => Reports.MoreThreeAsync(HouseofAll),
                () => Reports.UnicumAsync(HouseofAll),
                () => Reports.MostAsync(HouseofGrit),
                () => Reports.NotGridAsync(HouseofLiquid, HouseofAll, HouseofGrit));

            /*Task alotoftasks = new Task(() => Parallel.For(1, 3, Archi.md5));
            alotoftasks.Start();
            Task.WaitAll(alotoftasks);

            TaskFactory fac = new TaskFactory();
            var sixteen = fac.StartNew(() => Parallel.For(1, 3, No.md5));*/

            /*          string dir = @"D";
                        string road = @"D:Products.csv";*/
            string dir = @"E";
            string road = @"E:/rep/Products.csv";

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            dirInfo.Create();
            CSVsaving(HouseofAll, dir, road);
            CSVsaving(HouseofLiquid, dir, road);

            Console.WriteLine("trying");

            /* Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "System");
             foreach (Type t in typelist)
             {
                 Console.WriteLine(t.Name);
             }*/
            /*            var nameSpace = "System.Collections.Generic";
                        Type a = typeof(System.Collections.Generic.KeyValuePair);


                        Assembly asm = Assembly.LoadFrom(a.Namespace);

                        var classes = asm.GetTypes().Where(p =>
                             p.Namespace == nameSpace
                        ).ToList();
                        foreach (Type t in classes)
                        {
                            Console.WriteLine(t.Name);
                        }*/

            Assembly asm = Assembly.LoadFrom("C:/Program Files/dotnet/packs/Microsoft.NETCore.App.Ref/3.1.0/ref/netcoreapp3.1/System.Collections.dll");
            Console.WriteLine(asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t.Name);
            }
            Console.ReadLine();
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
