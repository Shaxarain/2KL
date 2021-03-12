using System;
using System.Collections;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Archi = new Employee("Arthur", "boss");
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

            string AdResult1 = HouseofLiquid.Adding(sugar);
            HouseofLiquid.Adding(aj);
            HouseofLiquid.Adding(bj);
            Console.WriteLine(AdResult1);

            string AdResult2 = HouseofObject.Addresp_emp(Archi);
            Console.WriteLine(AdResult2);

            

            //sum all warehouse

            /*foreach (IProduct lel in HouseofLiquid.products)
            {
                Console.WriteLine(lel.name);
            }*/
        }
    }
}
