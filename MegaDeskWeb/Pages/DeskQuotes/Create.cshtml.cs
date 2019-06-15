using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb;
using MegaDeskWeb.Models;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        public SelectList ShippingTypes{get;set;}
        public SelectList SurfaceMaterials{get;set;}
        private readonly MegaDeskWeb.Models.MegaDeskWebContext _context;

        public CreateModel(MegaDeskWeb.Models.MegaDeskWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateShippingTypes();
            PopulateSurfaceMaterials();
            return Page();
        }

        private void PopulateShippingTypes()
        {
            var shipping = from r in _context.RushShipping 
                            orderby r.RushShippingID
                            select r;
            SurfaceMaterials = new SelectList(shipping.AsNoTracking(),nameof(RushShipping.RushShippingID),nameof(RushShipping.RushShippingName));
        }        
        private void PopulateSurfaceMaterials()
        {
             var materials = from s in _context.SurfaceMaterial
                             orderby s.SurfaceMaterialID
                             select s;
            SurfaceMaterials = new SelectList(materials.AsNoTracking(),nameof(SurfaceMaterial.SurfaceMaterialID),nameof(SurfaceMaterial.SurfaceMaterialName));
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