using System;
using System.Collections.Generic;
using System.Text;

namespace Food
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public enum EmployeeType { VD = 1, Bagare = 2, Kassörska = 3 }

    }
}
