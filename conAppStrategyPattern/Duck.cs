using System;

namespace StrategyPattern
{
    /*
     * Problem statement
     *  When we want to build a type of object which can share common features/attribute 
     *      vertically(via Inheritance) And/Or horizontally (not possible using Inheritences)
     *      
     *      E.g.
     *          Creating Different type of Duck with similar/different feature
     *          In this case if different type of Duck are sharing similar or features e.g.
     *      
     *      
     *          ======== #1 - WildDuck=====================
                    > Simple fly (feature type - 1) !!!!
                    > quark simply (feature type - 1) !!!!
                    > Simple Display (feature type - 1) !!!!
                ===========================================

                ======== #2 - CityDuck=====================
                    > Simple Fly (feature type - 1) !!!!
                    > quark simply (feature type - 1) !!!!
                    > Fancy Display (feature type - 2) !!!!
                ===========================================

                ======== #3 - Rubber/ArtificialDuck=====================
                    > cannot fly (feature type - 2) !!!!
                    > cannot quark (feature type - 2) !!!!
                    > Fancy Display (feature type - 2) !!!!
                ========================================================

                ======== #4 - MountainDuck=====================
                    > JET fyling (feature type - 3) !!!!
                    > quark simply (feature type - 1) !!!!
                    > Simple Display (feature type - 1) !!!!
                ==============================================

                ======== #5 - AirDuck=====================
                    > JET fyling (feature type - 3) !!!!
                    > quark simply (feature type - 1) !!!!
                    > Fancy Display (feature type - 2) !!!!
                ===========================================
     */
    public class Duck
    {
        public IFlyingStrategy flyingStrategy;
        public IQuarkingStrategy quarkingStrategy;
        public IDisplayStrategy displayStrategy;

        public Duck(IFlyingStrategy flyingStrategy, IQuarkingStrategy quarkingStrategy, IDisplayStrategy displayStrategy)
        {
            this.flyingStrategy = flyingStrategy;
            this.quarkingStrategy = quarkingStrategy;
            this.displayStrategy = displayStrategy;
        }

        public void Fly()
        {
            this.flyingStrategy.Fly();
        }

        public void Quark()
        {
            this.quarkingStrategy.Quark();
        }
        public void Display()
        {
            this.displayStrategy.Display();
        }
    }

    public interface IFlyingStrategy
    {
        void Fly();
    }
    public class NoFlying : IFlyingStrategy
    {
        public void Fly()
        {
            Console.WriteLine("I cannot fly !!!!");
        }
    }
    public class SimplyFlying : IFlyingStrategy
    {
        public void Fly()
        {
            Console.WriteLine("I can fly but very simple way !!!!");
        }
    }
    public class JetFlying : IFlyingStrategy
    {
        public void Fly()
        {
            Console.WriteLine("I can fly like a JET fyling machine way !!!!");
        }
    }

    public interface IQuarkingStrategy
    {
        void Quark();
    }

    public class SimpleQuarking : IQuarkingStrategy
    {
        public void Quark()
        {
            Console.WriteLine("I can quark simply !!!!");
        }
    }
    public class NoQuarking : IQuarkingStrategy
    {
        public void Quark()
        {
            Console.WriteLine("I cannot quark !!!!");
        }
    }

    public interface IDisplayStrategy
    {
        void Display();
    }

    public class SimpleDisplay : IDisplayStrategy
    {
        public void Display()
        {
            Console.WriteLine("Simple Display !!!!");
        }
    }
    public class FancyDisplay : IDisplayStrategy
    {
        public void Display()
        {
            Console.WriteLine("Really Fancy Display !!!!");
        }
    }

}
