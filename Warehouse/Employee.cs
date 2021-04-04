using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Warehouse
{
    public class Employee
    {
        public string name { get; set; }
        public string position { get; set; }
        public Employee(string a, string b) { name = a; position = b; }
        public Warehouse Mywrh { get; set; }
        public delegate void Tasks(Object sender, AddProdEventArgs ea);
        public event Tasks NewTask;
        ConcurrentQueue<ICommand> ListCom = new ConcurrentQueue<ICommand>();
        public void ComsForEmp(IProduct product, int q)
        {
            ListCom.Enqueue(new WrhOnCom(Mywrh, product, q));
            NewTask?.Invoke(this, new AddProdEventArgs($"Task of adding {product.name} to warehouse {Mywrh.address.city} in amount {q} create", Mywrh.address, product.name, q));
        }
        public void Plus()
        {
            foreach (ICommand i in ListCom)
            {
                i.Execute();
            }
        }
        public void Minus()
        {
            foreach (ICommand i in ListCom)
            {
                i.Undo();
            }
        }
        public void md5(int count)
        {
            var md5 = MD5.Create();
            for (int i = 1; i < count + 1; i++)
            {
                Console.WriteLine($"{i} hash start");
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(this.name));
                Console.WriteLine(Convert.ToBase64String(result));
                Console.WriteLine($"{i} hash done");
            }
        }
    }
}
