﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Warehouse
{
    public class Warehouse
    {
        public Address address;
        public int area;
        public List<IProduct> products = new List<IProduct>();
        public bool type; //true = open
        public Employee main_emp;
        public int quantity;
        Catalog Cat = Catalog.getInstance();

        public delegate void AddProd(Object sender, AddProdEventArgs ea);
        public event AddProd AdProdNotify;
        public event AddProd UncorAddNotify;
        public event AddProd Hvnt;

        public Warehouse(Address a, int b, bool c) { address = a; area = b; type = c; }

        public void Adding(IProduct p, int q)
        {
            IProduct t = (IProduct)p.Clone();
            if (p == null)
            {
                Hvnt?.Invoke(this, new AddProdEventArgs("We haven't this product in catalog.", this.address, p.name, q));
            }
            if (p.type == "grit" && this.type == true)
            {
                UncorAddNotify?.Invoke(this, new AddProdEventArgs("Grit products are not added to open warehouses", this.address, p.name, q));
                throw new Exception("Grit products are not added to open warehouses");
            }
            else
            {
                if (!Finder(p.SKU)) //если в листе этого товара ещё нет
                {
                    t.quantity += q;
                    this.products.Add(t);
                    AdProdNotify?.Invoke(this, new AddProdEventArgs($"Product {p.name} added to warehouse {this.address.city} in amount {q}", this.address, p.name, q));
                }
                else
                {
                    foreach (IProduct i in this.products)
                    {
                        if (i.SKU == p.SKU)
                        {
                            i.quantity += q;
                            AdProdNotify?.Invoke(this, new AddProdEventArgs($"More product {p.name} added to warehouse {this.address.city} in amount {q} and now = {i.quantity}", this.address, p.name, q));
                        }
                    }
                }
            }
        }
        public void Delete(IProduct p, int q)
        {
            foreach (IProduct i in this.products)
            {
                if (i.SKU == p.SKU)
                {
                    i.quantity -= q;
                    AdProdNotify?.Invoke(this, new AddProdEventArgs($"Product {p.name} deleted from warehouse {this.address.city} in amount {q} and now = {i.quantity}", this.address, p.name, q));
                }
                else
                {
                    Hvnt?.Invoke(this, new AddProdEventArgs("We haven't this product in warehouse.", this.address, p.name, q));
                }
            }
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
                    b.Adding(a, q);
                    return $"{q} {i.name} was moving in quantity and there left = {i.quantity}";
                }
            }
            return "The product was not migrate";
        }
    }
}
