using System;
//
using System.Collections.Generic;
using System.Linq;

namespace AdapterPattern
{
    public class AdaptedEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public interface IAdapter
    {
        List<AdaptedEmployee> GetEmployees();
    }
    public class Adapter : IAdapter
    {
        Adaptee adaptee;
        public Adapter()
        {
            this.adaptee = new Adaptee();
        }

        public List<AdaptedEmployee> GetEmployees()
        {
            var employees = adaptee.GetThirdPartyEmployees();
            List<AdaptedEmployee> adaptedEmps =
                (
                    from e in employees
                    select new AdaptedEmployee() { FirstName = e.FName, LastName = e.LName }
                ).ToList<AdaptedEmployee>();

            return adaptedEmps;
        }
    }

    public class Adaptee
    {
        public List<Employee> GetThirdPartyEmployees()
        {
            return new List<Employee>()
            {
                new Employee(){FName = "Hasnen", LName="Siddique" },
                new Employee(){FName = "James", LName="Franklin" }
            };
        }
    }
    public class Employee
    {
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
