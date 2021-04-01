using System;
using System.Collections.Generic;
using System.Text;

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
        List<ICommand> ListCom = new List<ICommand>();
        public void ComsForEmp(IProduct product, int q)
        {
            ListCom.Add(new WrhOnCom(Mywrh, product, q));
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
    }
}
