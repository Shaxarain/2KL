using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class WrhOnCom : ICommand
    {
        Warehouse wh { get; set; }
        IProduct product { get; set; }
        int quantity { get; set; }

        public WrhOnCom(Warehouse w, IProduct p, int q)
        {
            wh = w;
            product = p;
            quantity = q;
        }
        public void Execute()
        {
            wh.Adding(product, quantity);
        }
        public void Undo()
        {
            wh.Delete(product, quantity);
        }
    }
}
