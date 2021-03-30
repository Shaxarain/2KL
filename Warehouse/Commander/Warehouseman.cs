using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class Warehouseman //Invoker
    {
        public Warehouseman() { }
        ICommand command;
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
