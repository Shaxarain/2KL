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
        public string main_emp;
        public int quantity;

        public Warehouse(string a, int b, bool c) { adress = a; area = b; type = c; }

        public string Adding(IProduct p)
        {
            if(p.type == "grit" && this.type == true)
            {
                return "Product not added to warehouse";
            }
            else
            {
                this.products.Add(p);
                return "Product added to warehouse";
            }
        }
        public string Addresp_emp(Employee e)
        {
            this.main_emp = e.name;
            return "This warehouse have a new main employee - " + e.name;
        }
    }
}
