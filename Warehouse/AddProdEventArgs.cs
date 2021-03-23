using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class AddProdEventArgs
    {
        public string AddProdMes;
        Address NameofWarehouse;
        string type = "adding";
        string NameofProd;
        DateTime time = DateTime.Now;

        public AddProdEventArgs(string a, Address b, string c) { AddProdMes = a; NameofWarehouse = b; NameofProd = c; }
    }
}
