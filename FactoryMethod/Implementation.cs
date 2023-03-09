// See https://aka.ms/new-console-template for more information

namespace FactoryMethod
{
    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }
        public override string ToString() => GetType().Name;
    }

    public class CountryDiscountService : DiscountService
    {
        private readonly string _countryIdentifier;

        public CountryDiscountService(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override int DiscountPercentage
        {
            get
            {
                switch (_countryIdentifier)
                {
                    case "BE": return 20;
                    default: return 10;
                }
            }
        }
    }

    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _guid;

        public CodeDiscountService(Guid guid)
        {
            _guid = guid;
        }

        public override int DiscountPercentage
        {
            get => 15;
        }
    }

    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }

    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string _countryIdentifier;

        public CountryDiscountFactory(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }


        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_countryIdentifier);
        }
    }

    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _guid;

        public CodeDiscountFactory(Guid guid)
        {
            _guid = guid;
        }


        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_guid);
        }
    }

}
