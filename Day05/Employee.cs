using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string? Fullname { get; set; }

        public override string? ToString()
        {
            return $"Employee ID : {EmpID} , Name : {Fullname}";
        }
    }
}