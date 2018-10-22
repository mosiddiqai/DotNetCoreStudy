using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ////OCP (Open Closed Principle)
            //Console.WriteLine("================================================");
            //Console.WriteLine("Using Tradition Car object");
            //Console.WriteLine("================================================");
            //OCP.Car c = new OCP.Car();
            //Console.WriteLine("Applying brakes to car!!");
            //c.Brake();
            //Console.WriteLine("================================================");


            //Console.WriteLine("================================================");
            //Console.WriteLine("Using the Car with extension");
            //Console.WriteLine("================================================");
            //OCP.CarExtension ce = new OCP.CarExtension();
            //Console.WriteLine("Applying brakes to car!!");
            //ce.Brake();
            //Console.WriteLine("================================================"); 
            #endregion


            ////LSP (Liskov Substitution Principle)


            #region Simple example commented

            Console.WriteLine("================================================");
            Console.WriteLine("Using Tradition Car object");
            Console.WriteLine("================================================");

            //
            //LSP.Car c = new LSP.Car("Traditional");
            //c.Drive();
            //Console.WriteLine("================================================");


            //Console.WriteLine("================================================");
            //Console.WriteLine("Using the Car with Tesla");
            //Console.WriteLine("================================================");
            //c = new LSP.TeslaCar("Tesla");
            //Console.WriteLine("Applying brakes to car!!");
            //c.Drive(); 
            #endregion


            #region LSP
            //////////LSP.Employee empPermanent = new LSP.PermanentEmployee(1001);
            ////////LSP.EmployeeBonus empPermanent = new LSP.PermanentEmployee(1001);
            ////////Console.WriteLine("Employe : ");
            ////////empPermanent.DisplayEmployeeDetails();
            ////////Console.WriteLine("Bonus : " + empPermanent.CalculateBonus(1000));

            //////////LSP.Employee empTemp = new LSP.TemporaryEmployee(1002);
            ////////LSP.EmployeeBonus empTemp = new LSP.TemporaryEmployee(1002);
            ////////Console.WriteLine("Employe : ");
            ////////empTemp.DisplayEmployeeDetails();
            ////////Console.WriteLine("Bonus : " + empTemp.CalculateBonus(1000));

            ////////Console.WriteLine("================================================");
            #endregion

            #region IOC

            Console.WriteLine("================================================");
            //Classic code approach of
            //User u = new User();
            //u.Add();

            //Using IOC - i.e. Inverting the responsibility of creating DAL object to Client instead of User class
            User u = new User(new MsSqlDal());
            u.Add();

                // Doing so will help to handle scenarios when we have multiple database to store via Interface
            

            Console.WriteLine("================================================");

            #endregion


            Console.ReadLine();
        }
    }
}
