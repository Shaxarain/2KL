using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Warehouse
{
    public class MyAttribute : System.Attribute
    {
        public string numb { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string SKU { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public MyAttribute(string numb, string name, string type, string SKU, string description, string price, string quantity)
        { this.numb = numb; this.name = name; this.type = type; this.SKU = SKU; this.description = description; this.price = price; this.quantity = quantity; }
    }
    [My("Number", "Name", "Type", "SKU", null, "Price", "Quantity")]
    public class Excell
    {
        public static void CSVsaving(Warehouse a, string b, string c)
        {

            if (Directory.Exists(b))
            {
                int count = 1;
                Type t = typeof(Excell);

                var pi = t.GetProperty("Name");
                object [] aaaaaaaaa = t.GetProperties();

                var k = typeof(Excell).GetCustomAttributes(typeof(MyAttribute), false);
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);

                using (StreamWriter sw = new StreamWriter(c, true, System.Text.Encoding.Default))
                {
                    foreach (System.Attribute i in attrs)
                    {
                        MyAttribute ma = (MyAttribute)i;
                        sw.Write($"{ma.numb};{ma.name};{ma.type};{ma.SKU};{ma.description};{ma.price};{ma.quantity};");
                    }
                    sw.WriteLine();
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
    }
}
