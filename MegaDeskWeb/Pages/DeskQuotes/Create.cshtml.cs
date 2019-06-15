using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        public SelectList shippingTypes;
        private readonly MegaDeskWeb.Models.MegaDeskWebContext _context;

        public CreateModel(MegaDeskWeb.Models.MegaDeskWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        PopulateShipping();
        ViewData["RushShippingID"] = new SelectList(_context.Set<RushShipping>(), "RushShippingID", "RushShippingName");
            return Page();
        }

        private void PopulateShipping()
        {
            var shipping = from r in _context.RushShipping select r;
            shippingTypes = new SelectList(shipping, "RushShippingName");
        }
        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}