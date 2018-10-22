using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Strategy Pattern in action with Duck (i.e. behavior changing both horizontally & vertically)
            ////////Various attributes of different Duck can contains
            //////IFlyingStrategy simpleFlying = new SimplyFlying();
            //////IFlyingStrategy jetFlying = new JetFlying();
            //////IFlyingStrategy noFlying = new NoFlying();
            //////IQuarkingStrategy simpleQuarking = new SimpleQuarking();
            //////IQuarkingStrategy noQuarking = new NoQuarking();
            //////IDisplayStrategy simpleDisplay = new SimpleDisplay();
            //////IDisplayStrategy fancyDisplay = new FancyDisplay();

            ////////Building a WildDuck
            //////Console.WriteLine("========Building WildDuck=====================");
            //////Duck wildDuck = new Duck(simpleFlying, simpleQuarking, simpleDisplay);
            //////wildDuck.Fly();
            //////wildDuck.Quark();
            //////wildDuck.Display();
            //////Console.WriteLine("==============================================");

            ////////Building a CityDuck
            //////Console.WriteLine("========Building CityDuck=====================");
            //////Duck cityDuck = new Duck(simpleFlying, simpleQuarking, fancyDisplay);
            //////cityDuck.Fly();
            //////cityDuck.Quark();
            //////cityDuck.Display();
            //////Console.WriteLine("==============================================");

            ////////Building a RubberDuck
            //////Console.WriteLine("========Building Rubber/ArtificialDuck=====================");
            //////Duck rubberDuck = new Duck(noFlying, noQuarking, fancyDisplay);
            //////rubberDuck.Fly();
            //////rubberDuck.Quark();
            //////rubberDuck.Display();
            //////Console.WriteLine("==============================================");

            ////////Building a MountainDuck
            //////Console.WriteLine("========Building MountainDuck=====================");
            //////Duck mountainDuck = new Duck(jetFlying, simpleQuarking, simpleDisplay);
            //////mountainDuck.Fly();
            //////mountainDuck.Quark();
            //////mountainDuck.Display();
            //////Console.WriteLine("==============================================");

            ////////Building a AirDuck
            //////Console.WriteLine("========Building AirDuck=====================");
            //////Duck airDuck = new Duck(jetFlying, simpleQuarking, fancyDisplay);
            //////airDuck.Fly();
            //////airDuck.Quark();
            //////airDuck.Display();
            //////Console.WriteLine("=============================================="); 
            #endregion

            #region Strategy Pattern in action with Discount Strategy 
            //////////int totalAmount = 1000;
            //////////int discountedAmount = 0;
            //////////Console.WriteLine("========Frequent Customer discounts=====================");
            //////////Discounts discounts = new Discounts(new FrequentCustomerDiscountStrategy());
            //////////discountedAmount = discounts.ApplyDiscounts(totalAmount);
            //////////Console.WriteLine($"Billing amount : {totalAmount}, post discounts : {discountedAmount}, final amount : {totalAmount - discountedAmount}");
            //////////Console.WriteLine("==============================================");

            //////////Console.WriteLine("========Normal Customer discounts=====================");
            //////////discounts = new Discounts(new NormalCustomerDiscountStrategy());
            //////////discountedAmount = discounts.ApplyDiscounts(totalAmount);
            //////////Console.WriteLine($"Billing amount : {totalAmount}, post discounts : {discountedAmount}, final amount : {totalAmount - discountedAmount}");
            //////////Console.WriteLine("==============================================");

            //////////Console.WriteLine("========Weekend discounts=====================");
            //////////discounts = new Discounts(new WeekendDiscountStrategy());
            //////////discountedAmount = discounts.ApplyDiscounts(totalAmount);
            //////////Console.WriteLine($"Billing amount : {totalAmount}, post discounts : {discountedAmount}, final amount : {totalAmount - discountedAmount}");
            //////////Console.WriteLine("==============================================");

            #endregion

            Console.ReadLine();
        }
    }
}
