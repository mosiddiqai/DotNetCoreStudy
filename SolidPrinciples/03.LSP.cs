using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.LSP
{

    /*
     * Liskov subsition Principle - states that derive class should be capable to subsitute base class completely
     *      i.e. 
     *      > Derive class should consists of 
     *      > derive class shouldn't introduce any new exception which is not known to Base class
     *      
     */

    //Simple example of LSP
    //public class Car
    //{
    //    private string _carName;
    //    public Car(string carname)
    //    {
    //        this._carName = carname;
    //    }
    //    public void Drive()
    //    {
    //        Console.WriteLine(_carName + " Car is driving via base class");
    //    }
    //}

    //public class TeslaCar : Car
    //{
    //    public TeslaCar(string _carName) : base(_carName)
    //    {

    //    }
    //}

    /*
     * as explained - we are creating Employee type object with full functionality
     * 1) DisplayEmployeeDetails
     * 2) CalculateBonus
     * 
     * 3) we are creating different type of derive class of Employee (e.g. Permanent, Temporary & Contractor)
     *  3.1) PermanentEmployee ==> is provided with Bonus twice the salary
     *  3.2) TemporaryEmployee ==> is provided with 0.5 times of the salary
     *  3.3) Contractors ==> Is not allowed to have any Bonus
     *  
     * 4) Here since ContractorEmployee is not allowed with Bonus, hence it violates LSP
     *  4.1) I.e. We will inherit the Base class Employee and cannot provide definition of CalculateBonus method
     *  
     *  
     * SOLUTION:
     *  1) Move such method/feature/functionality which cant be replace in derive class into separate object (i.e. Interface)
     *  2) Inherit the same 
     */

    /*
     * PROBLEM IN DESING
     * Since we are having while creating ContractorEmployee - as we dont wont to allow Bonus to contractor employees
     *  However, as per design since "Employee" base class 
     *      consists of "CalculateBonus" method which then enforce to have Bonus feature to contractor employees as well
     *      
     *  Due to this behavior ContractorEmployee is not directly substitable to "Employee"
     */

    /*
     * SOLUTION 
     *  We shall keep only common cofunctionality in Base class and let inherit other feature in different e.g.
     *      a) via Multiple Inheritance in each derive classes
     *          a.1) Employee class should not consists of "CalculateBonus"
     *          a.2) Move the "CalculateBonus" in separate interface 
     *      b) create 2 separate base class 
     *          b.1) EmployeeWithBonus ==> to be used with PermanentEmployee & TemporaryEmployee
     *          b.2) Inherit the feature in each derive class
     */

    public abstract class Employee
    {
        int employeeId;

        public Employee( int empID)
        {
            this.employeeId = empID;
        }
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine("Employee ID : " + this.employeeId);
        }
        //public abstract decimal CalculateBonus(decimal salary);
    }

    public abstract class EmployeeBonus : Employee
    {
        public EmployeeBonus(int empID) : base(empID) { }
        public abstract decimal CalculateBonus(decimal salary);
    }

    //Solution
    //public abstract class EmployeeWithsBonus : Employee
    public abstract class EmployeeWithsBonus : EmployeeBonus
    {
        public EmployeeWithsBonus(int empID) : base(empID) { }

        public override decimal CalculateBonus(decimal salary)
        {
            return salary;
        }
    }


    //public class PermanentEmployee : Employee
    public class PermanentEmployee : EmployeeWithsBonus
    {
        public PermanentEmployee(int empID) : base(empID) { }

        //public override decimal CalculateBonus(decimal salary) // prototype via initial Abstract base class
        public override decimal CalculateBonus(decimal salary)
        {
            return salary * 2;
        }
    }
    //public class TemporaryEmployee : Employee
    public class TemporaryEmployee : EmployeeWithsBonus
    {
        public TemporaryEmployee(int empID) : base(empID) { }

        //public override decimal CalculateBonus(decimal salary) // prototype via initial Abstract base class
        public decimal CalculateBonus(decimal salary)
        {
            return salary * 0.5M;
        }
    }

    public class ContractorEmployee : Employee
    {
        public ContractorEmployee(int empID) : base(empID) { }
    }

}
