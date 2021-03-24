using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    public class AddProdEventArgs
    {
        public string AddProdMes;
        Address NameofWarehouse;
        string type = "adding";
        string NameofProd;
        int AmProd;
        DateTime time = DateTime.Now;

        public AddProdEventArgs(string a, Address b, string c, int d) { AddProdMes = a; NameofWarehouse = b; NameofProd = c; AmProd = d; }
    }
}
