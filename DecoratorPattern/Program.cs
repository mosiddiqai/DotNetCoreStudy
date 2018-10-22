using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===============Building Express with Caremol===============");
            Beverages beverages;// = new CaremolDecorator(new ExpressoBeverage());
            
            //Decorating the object basis user/client requirement
            beverages = new ExpressoBeverage();
            if (1 == 1)
            {
                //I want caremol as well
                beverages = new CaremolDecorator(beverages);
            }
            Console.WriteLine($"Coffee description : {beverages.GetDescription()}");
            Console.WriteLine($"Coffee cost : {beverages.GetCost()}");
            Console.WriteLine("================END========================================");

            Console.WriteLine("===============Building Express with Caremol (X2) ===============");
            //Simple approach
            //CaremolDecorator caremolDecorator = new CaremolDecorator(new ExpressoBeverage());
            //caremolDecorator.MultipleAddOn = 2;
            //beverages = caremolDecorator;
            //Console.WriteLine($"Coffee description : {beverages.GetDescription()}");
            //Console.WriteLine($"Coffee cost : {beverages.GetCost()}");

            //building as per need approach
            beverages = new ExpressoBeverage();
            if (1 == 1)
            {
                //I want caremol as well (2 twice)
                CaremolDecorator caremolDecorator = new CaremolDecorator(beverages);
                caremolDecorator.MultipleAddOn = 2;
                beverages = caremolDecorator;
            }
            Console.WriteLine($"Coffee description : {beverages.GetDescription()}");
            Console.WriteLine($"Coffee cost : {beverages.GetCost()}");

            Console.WriteLine("================END========================================");

            Console.WriteLine("===============Building Express with Caremol & Soly===============");
            beverages = new SolyDecorator(new CaremolDecorator(new ExpressoBeverage()));
            Console.WriteLine($"Coffee description : {beverages.GetDescription()}");
            Console.WriteLine($"Coffee cost : {beverages.GetCost()}");
            Console.WriteLine("================END========================================");

            Console.WriteLine("===============Building Decayata with Caremol===============");
            beverages = new CaremolDecorator(new DecayataBeverage());
            Console.WriteLine($"Coffee description : {beverages.GetDescription()}");
            Console.WriteLine($"Coffee cost : {beverages.GetCost()}");
            Console.WriteLine("================END========================================");

            Console.WriteLine("===============Building Decayata with Caremol & Soly===============");
            beverages = new SolyDecorator(new CaremolDecorator(new DecayataBeverage()));
            Console.WriteLine($"Coffee description : {beverages.GetDescription()}");
            Console.WriteLine($"Coffee cost : {beverages.GetCost()}");
            Console.WriteLine("================END========================================");

            Console.ReadLine();
        }
    }
}
