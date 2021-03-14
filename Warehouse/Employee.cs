using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class Employee
    {
        public string name { get; set; }
        public string position { get; set; }
        public Employee(string a, string b) { name = a; position =b; }
    }
}
