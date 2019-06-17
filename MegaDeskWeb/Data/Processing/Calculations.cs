using System;
using System.Linq;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Data.Processing
{
    public class Calculations
    {
        public static DeskQuote PopulateQuote(DeskQuote incompleteQuote, int shipSelector, SurfaceMaterial material, MegaDeskWebContext context)
        {
            incompleteQuote.Desk.SurfaceMaterial = material;
            incompleteQuote.Desk.SurfaceMaterialID = material.SurfaceMaterialID;
            decimal surfaceArea = incompleteQuote.Desk.Width * incompleteQuote.Desk.Depth;
            decimal price = 200;

            // add surfacematerial price
            price += incompleteQuote.Desk.SurfaceMaterial.SurfaceMaterialPrice;
            // add drawer price
            price += incompleteQuote.Desk.NumDrawers * 50;
            // add additional material price
            if (surfaceArea > 1000)
            {
                price += surfaceArea - 1000;
            }

            // populate RushShipping field. 
            switch (shipSelector)
            {
                case 3:
                    if (surfaceArea <= 1000)
                    {
                        incompleteQuote.RushShipping = context.RushShipping.Where(p => p.RushShippingName == "Three-Day Small").SingleOrDefault();
                    }
                    else if (surfaceArea < 2000)
                    {
                        incompleteQuote.RushShipping = context.RushShipping.Where(p => p.RushShippingName == "Three-Day Medium").SingleOrDefault();
                    }
                    else
                    {
                        incompleteQuote.RushShipping = context.RushShipping.Where(p => p.RushShippingName == "Three-Day Large").SingleOrDefault();
                    }
                    break;
                case 5:
                    if (surfaceArea <= 1000)
                    {
                        incompleteQuote.RushShipping = context.RushShipping.Where(p => p.RushShippingName == "Five-Day Small").SingleOrDefault();
                    }
                    else if (surfaceArea < 2000)
                    {
                        incompleteQuote.RushShipping = context.RushShipping.Where(p => p.RushShippingName == "Five-Day Medium").SingleOrDefault();
                    }
                    else
                    {
                        incompleteQuote.RushShipping = context.RushShipping.Where(p => p.RushShippingName == "Five-Day Large").SingleOrDefault();
                    }
                    break;
                case 7:
                    if (surfaceArea <= 1000)
                    {
                        incompleteQuote.RushShipping = context.RushShipping.Where(p => p.RushShippingName == "Seven-Day Small").SingleOrDefault();
                    }
                    else if (surfaceArea < 2000)
                    {
                        incompleteQuote.RushShipping = context.RushShipping.Where(p => p.RushShippingName == "Seven-Day Medium").SingleOrDefault();
                    }
                    else
                    {
                        incompleteQuote.RushShipping = (RushShipping)context.RushShipping.Where(p => p.RushShippingName == "Seven-Day Large");
                    }
                    break;
                default:
                    {
                        incompleteQuote.RushShipping = new RushShipping { RushShippingID = 0, RushShippingName = "standard", RushShippingPrice = 0 };
                        break;
                    }
            }
            price += incompleteQuote.RushShipping.RushShippingPrice;
            incompleteQuote.Price = price;
            DeskQuote completeQuote = incompleteQuote;
            return completeQuote;
        }


    }
}