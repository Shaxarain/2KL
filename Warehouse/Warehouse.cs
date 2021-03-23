﻿using System;
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

        public delegate void AddProd(Object sender, AddProdEventArgs ea);
        public event AddProd AdProdNotify;
        public event AddProd UncorAddNotify;

        public Warehouse(Address a, int b, bool c) { address = a; area = b; type = c; }

        public void Adding(IProduct p, int q)
        {
            IProduct t = (IProduct)p.Clone();
            if (p.type == "grit" && this.type == true)
            {
                UncorAddNotify?.Invoke(this, new AddProdEventArgs("Grit products are not added to open warehouses", this.address, p.name));
                throw new Exception("Grit products are not added to open warehouses");
            }
            else
            {
                if (!Finder(p.SKU)) //если в листе этого товара ещё нет
                {
                    t.quantity += q;
                    this.products.Add(t);
                    AdProdNotify?.Invoke(this, new AddProdEventArgs("Product added to warehouse", this.address, p.name));
                }
                else
                {
                    foreach (IProduct i in this.products)
                    {
                        if (i.SKU == p.SKU)
                        {
                            i.quantity += q;
                            AdProdNotify?.Invoke(this, new AddProdEventArgs("Product added to warehouse", this.address, p.name));
                        }
                    }
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
                money += i.price*i.quantity;
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
                    return i.name + " was moving and quantity there = " + i.quantity;
                }
            }
            b.Adding(a, q);
            return "The product was migrate";
        }
    }
}
