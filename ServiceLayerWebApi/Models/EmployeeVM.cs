using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayerWebApi.Models
{
    public class EmployeeVM
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
    }
}