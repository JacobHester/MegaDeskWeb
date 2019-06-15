using System.Linq;

namespace MegaDeskWeb.Models
{
    public static class DbInitializer
    {        
        public static void Initialize(MegaDeskWebContext context)
        {
            if (context.RushShipping.Any())
            {
                return; //DB is already seeded.
            }
            var shippingPrices = new RushShipping[]
            {
                new RushShipping{RushShippingName="OneDayLarge",RushShippingPrice=80},
                new RushShipping{RushShippingName="OneDayMedium",RushShippingPrice=70},
                new RushShipping{RushShippingName="OneDaySmall",RushShippingPrice=60},
                new RushShipping{RushShippingName="ThreeLarge",RushShippingPrice=60},
                new RushShipping{RushShippingName="ThreeDayMedium",RushShippingPrice=50},
                new RushShipping{RushShippingName="ThreeDaySmall",RushShippingPrice=40},
                new RushShipping{RushShippingName="FiveDayLarge",RushShippingPrice=40},
                new RushShipping{RushShippingName="FiveDayMedium",RushShippingPrice=35},
                new RushShipping{RushShippingName="FiveDaySmall",RushShippingPrice=30}
            };
            foreach (RushShipping rS in shippingPrices)
            {
                context.Add(rS);
            }
            context.SaveChanges();
        }
    }
}