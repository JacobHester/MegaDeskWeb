using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MegaDeskWeb
{
    public class DeskQuote
    {
        public int DeskQuoteID { get; set; }
        public int DeskID { get; set; }
        public Desk Desk { get; set; }
        public string Name { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal Price { get; set; }
        public int RushShippingID { get; set; }
        [BindProperty]
        public RushShipping RushShipping { get; set; }

    }


}
