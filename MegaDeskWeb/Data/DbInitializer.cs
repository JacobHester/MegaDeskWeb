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
                new RushShipping{RushShippingName="One-Day Large",RushShippingPrice=80},
                new RushShipping{RushShippingName="One-Day Medium",RushShippingPrice=70},
                new RushShipping{RushShippingName="One-Day Small",RushShippingPrice=60},
                new RushShipping{RushShippingName="Three-Day Large",RushShippingPrice=60},
                new RushShipping{RushShippingName="Three-Day Medium",RushShippingPrice=50},
                new RushShipping{RushShippingName="Three-Day Small",RushShippingPrice=40},
                new RushShipping{RushShippingName="Five-Day Large",RushShippingPrice=40},
                new RushShipping{RushShippingName="Five-Day Medium",RushShippingPrice=35},
                new RushShipping{RushShippingName="Five-Day Small",RushShippingPrice=30}
            };
            foreach (RushShipping rS in shippingPrices)
            {
                context.Add(rS);
            }
            context.SaveChanges();
            var surfaceMaterials= new SurfaceMaterial[]{
                new SurfaceMaterial{SurfaceMaterialName="Oak",SurfaceMaterialPrice=200},
                new SurfaceMaterial{SurfaceMaterialName="Laminate",SurfaceMaterialPrice=100},
                new SurfaceMaterial{SurfaceMaterialName="Pine",SurfaceMaterialPrice=50},
                new SurfaceMaterial{SurfaceMaterialName="Rosewood",SurfaceMaterialPrice=300},
                new SurfaceMaterial{SurfaceMaterialName="Veneer",SurfaceMaterialPrice=125}
            };
            foreach(SurfaceMaterial s in surfaceMaterials)
            {
                context.Add(s);
            }
            context.SaveChanges();
        }
    }
}