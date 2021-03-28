using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    public class Catalog
    {
        private static Catalog instance = null;
        private List<IProduct> CoP;

        IProduct poison = new LiquidProduct("poison", "000", 666);
        IProduct aj = new LiquidProduct("apple juice", "010", 560);
        IProduct bj = new LiquidProduct("berry juice", "011", 600);
        IProduct sugar = new GritProduct("sygar", "100", 500);
        IProduct cocaine = new GritProduct("coconut flakes", "101", 3000);
        IProduct heart = new ObjectProduct("heart of human", "200", 5000);
        IProduct mouse = new ObjectProduct("dead mouse", "201", 0);
        public static Catalog getInstance()
        {
            if (instance == null)
                instance = new Catalog();
            return instance;
        }
        protected Catalog()
        {
            CoP = new List<IProduct> { poison, aj, bj, sugar, cocaine, heart, mouse };
            cocaine.description = "Not a cocaine";
        }
        public IProduct Buying(string sku)
        {
            foreach (IProduct cpr in CoP)
            {
                if (sku == cpr.SKU)
                {
                    return cpr;
                }
            }
            return null;
        }
    }
}
