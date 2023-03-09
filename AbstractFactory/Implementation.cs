using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface IShippingCostsService
    {
        decimal ShippingCosts { get; }
    }

    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    public interface IShoppingCartPurchaseFactory
    {
        public IShippingCostsService CreateShippingCostsService();
        public IDiscountService CreateDiscountService();
    }

    public class BelgiumShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 20;
    }

    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    public class FranceShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }

    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IShippingCostsService CreateShippingCostsService()
        {
            return new BelgiumShippingCostsService();
        }

        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }
    }

    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostsService();
        }

        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

    }

    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

   

    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCostsService();
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total cost = " +
                $"{_orderCosts - (_orderCosts/100  * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
        }
    }
}