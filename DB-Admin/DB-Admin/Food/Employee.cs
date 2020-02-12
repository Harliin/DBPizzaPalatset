using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Admin
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public EType EmployeeType { get; set; }
        public enum EType { Admin = 1, Bagare = 2, Kassörska = 3}

    }
}
