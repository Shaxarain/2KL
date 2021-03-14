using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Warehouse
{
    class Warehouse
    {
        Address address;
        public int area;
        public ArrayList products = new ArrayList();
        public bool type; //true = open
        public string main_emp;
        public int quantity;

        public Warehouse(Address a, int b, bool c) { address = a; area = b; type = c; }

        public string Adding(IProduct p, int q)
        {
            IProduct t = (IProduct)p.Clone();
            if (p.type == "grit" && this.type == true)
            {
                return "Product " + p.name + " not added to warehouse ";
            }
            else
            {
                if (!Finder(p.SKU)) //если в листе этого товара ещё нет
                {
                    t.quantity += q;
                    this.products.Add(t);
                    return "Product " + p.name + " added to warehouse and quantity = " + q;
                }
                else
                {
                    foreach (IProduct i in this.products)
                    {
                        if (i.SKU == p.SKU)
                        {
                            i.quantity += q;
                            return "Now quantity of " + i.name + " = " + i.quantity;
                        }
                    }
                    return "lel";
                }
            }
        }
        public string Addresp_emp(Employee e)
        {
            this.main_emp = e.name;
            return "This warehouse have a new main employee - " + e.name;
        }
        public string SKUfinder(string a)
        {
            foreach (IProduct i in this.products)
            {
                if (i.SKU == a)
                {
                    return "Product with this USK is " + i.name;
                }
            }
            return "No this product on this warehouse";
        }
        public bool Finder(string a)
        {
            foreach (IProduct i in this.products)
            {
                if (i.SKU == a)
                {
                    return true;
                }
            }
            return false;
        }

        public int Totalprice()
        {
            int money = 0;
            foreach(IProduct i in this.products)
            {
                money += i.price;
            }
            return money;
        }
        public string Move(IProduct a, Warehouse b, int q)
        {
            foreach (IProduct i in this.products)
            {
                if (i.SKU == a.SKU)
                {
                    i.quantity -= q;
                    return "Now quantity of " + i.name + " = " + i.quantity;
                }
            }
            b.Adding(a, q);
            return "The product was migrate";
        }
    }
}
