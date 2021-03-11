using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Warehouse
{
    class Warehouse
    {
        public string adress;
        public int area;
        public ArrayList products = new ArrayList();
        public bool type; //true = open
        public string resp_emp;
        public int quantity;

        public Warehouse(string a, int b, bool c) { a = adress; b = area; c = type; }

        Boolean isOpen()
        {
            if (type == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Adding(IProduct p)
        {
            if(p.type == "grit" && type == true)
            {
                return "Product not added to warehouse";
            }
            else
            {
                this.products.Add(p);
                return "Product added to warehouse";
            }
        }
    }
}
