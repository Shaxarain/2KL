using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class Address
    {
        public string city { get; set; }
        string street { get; set; }
        int number { get; set; }

        public Address(string a, string b, int c) { city = a; street = b; number = c; }
    }
}
