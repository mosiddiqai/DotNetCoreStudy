using System;


namespace SolidPrinciples.OCP
{
    public class Car
    {
        public void Brake()
        {
            Console.WriteLine("The car is applying brakes!");
        }
    }

    public class CarExtension : Car
    {
        public new void Brake()
        {
            base.Brake();

            BrakeLights();
        }

        public void BrakeLights()
        {
            Console.WriteLine("Extended, turning on brake light as well!");
        }
    }
}
