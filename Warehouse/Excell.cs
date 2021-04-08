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
        public MyAttribute(string a, string b, string c, string d, string e, string f, string g)
        { numb = a; name = b;  type = c; SKU = d; description = e; price = f; quantity = g; }
    }
    [My("Number", "Name", "Type", "SKU", "Desription", "Price", "Quantity")]
    class Excell
    {
        public static string numb = "Number";
        public static string name = "Name";
        public static string type = "Type";
        public static string SKU = "SKU";
        public static string description = "Description";
        public static string price = "Price";
        public static string quantity = "Quantity";
        public static void CSVsaving(Warehouse a, string b, string c)
        {
            string head = $"{numb};{name};{type};{SKU};{description};{price};{quantity};";
            if (Directory.Exists(b))
            {
                int count = 1;
                using (StreamWriter sw = new StreamWriter(c, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(head);
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
