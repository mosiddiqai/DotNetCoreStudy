

namespace StrategyPattern
{
    public class Discounts
    {
        IDiscountsStrategy discountsStrategy;

        public Discounts(IDiscountsStrategy discountsStrategy)
        {
            this.discountsStrategy = discountsStrategy;
        }

        public int ApplyDiscounts(int amount)
        {
            return this.discountsStrategy.ApplyDiscounts(amount);
        }
    }

    public interface IDiscountsStrategy
    {
        int ApplyDiscounts(int amount);
    }

    public class FrequentCustomerDiscountStrategy : IDiscountsStrategy
    {
        public int ApplyDiscounts(int amount)
        {
            return ((amount * 20) / 100);
        }
    }

    public class NormalCustomerDiscountStrategy : IDiscountsStrategy
    {
        public int ApplyDiscounts(int amount)
        {
            return ((amount * 5) / 100);
        }
    }

    public class WeekendDiscountStrategy : IDiscountsStrategy
    {
        public int ApplyDiscounts(int amount)
        {
            return ((amount * 25) / 100);
        }
    }
}
