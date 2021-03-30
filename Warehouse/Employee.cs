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
        public Warehouse Mywrh;

        ICommand command;
        List<ICommand> ListCom = new List<ICommand>();
        public void ComForWman(ICommand com)
        {
            command = com;
        }
        public void Deliver()
        {
            command.Execute();
        }
        public void Takeaway()
        {
            command.Undo();
        }
    }
}
