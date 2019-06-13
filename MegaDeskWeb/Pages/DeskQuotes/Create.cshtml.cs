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
        private readonly MegaDeskWeb.Models.MegaDeskWebContext _context;

        public CreateModel(MegaDeskWeb.Models.MegaDeskWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeskID"] = new SelectList(_context.Set<Desk>(), "DeskID", "DeskID");
        ViewData["RushShippingID"] = new SelectList(_context.Set<RushShipping>(), "RushShippingID", "RushShippingID");
            return Page();
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