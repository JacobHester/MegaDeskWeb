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
        private readonly MegaDeskWeb.Models.MegaDeskWebContext _context;

        public IndexModel(MegaDeskWeb.Models.MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }


        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync()
        {
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
