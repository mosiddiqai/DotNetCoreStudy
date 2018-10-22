

namespace DecoratorPattern
{
    public abstract class Beverages
    {
        public abstract string GetDescription();
        public abstract int GetCost();
    }
    public class ExpressoBeverage : Beverages
    {
        public override int GetCost()
        {
            return 10;
        }

        public override string GetDescription()
        {
            return "Expresso coffee";
        }
    }
    public class DecayataBeverage : Beverages
    {
        public override int GetCost()
        {
            return 20;
        }

        public override string GetDescription()
        {
            return "Decayata coffee";
        }
    }


    public abstract class AddOnDecorator : Beverages
    {
        public int MultipleAddOn { get; set; }
    }

    public class CaremolDecorator : AddOnDecorator
    {
        public Beverages beverage;
        public CaremolDecorator(Beverages beverage)
        {
            this.beverage = beverage;
        }
        public override int GetCost()
        {
            return this.beverage.GetCost() + (MultipleAddOn > 1 ? 2 * MultipleAddOn : 2);
        }

        public override string GetDescription()
        {
            string addOn = MultipleAddOn > 1 ? $" ( {MultipleAddOn} times  )" : "";
            return $"{this.beverage.GetDescription() }, addon : Caremol {addOn}"; 
        }
    }

    public class SolyDecorator : AddOnDecorator
    {
        public Beverages beverage;
        public SolyDecorator(Beverages beverage)
        {
            this.beverage = beverage;
        }
        public override int GetCost()
        {
            return this.beverage.GetCost() + (MultipleAddOn > 1 ? 3 * MultipleAddOn : 3);
        }

        public override string GetDescription()
        {
            string addOn = MultipleAddOn > 1 ? $" ( {MultipleAddOn} times  )" : "";
            return $"{this.beverage.GetDescription() }, addon : Soly {addOn}";
        }
    }

}
