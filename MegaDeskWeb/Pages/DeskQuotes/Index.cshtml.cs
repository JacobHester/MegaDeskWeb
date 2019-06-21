using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        private readonly MegaDeskWeb.Models.MegaDeskWebContext _context;

        public IndexModel(MegaDeskWeb.Models.MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }


        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
        
            NameSort = String.IsNullOrEmpty(sortOrder)? "name_desc": "";
            DateSort = sortOrder == "Date" ? "date_desc":"date";

            IQueryable<DeskQuote> deskQuoteIQ = from d in _context.DeskQuote
                                                select d;

            switch (sortOrder)
            {
                case "name_desc":
                deskQuoteIQ = deskQuoteIQ.OrderByDescending(d => d.Name);
                break;

                case "Date" : 
                deskQuoteIQ = deskQuoteIQ.OrderBy(d => d.QuoteDate);
                break;

                case "date_desc":
                deskQuoteIQ = deskQuoteIQ.OrderByDescending(d => d.QuoteDate);
                break;

                default:
                deskQuoteIQ = deskQuoteIQ.OrderBy(d => d.Name);
                break;
            }
            
            DeskQuote = await deskQuoteIQ
                .Include(d => d.Desk)
                .Include(d => d.RushShipping).ToListAsync();
            var names = from m in _context.DeskQuote
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                names = names.Where(s => s.Name.Contains(SearchString));
            }

            DeskQuote = await names.ToListAsync();
        }
    }
}
