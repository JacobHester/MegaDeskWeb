using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb;
using MegaDeskWeb.Models;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Data.Processing;

namespace MegaDeskWeb.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
            
        [BindProperty]
        public int SelectedShip { get; set; }
        [BindProperty]
        public int localMaterialID { get; set; }
        public List<SelectListItem> ShippingTypes{get;set;}
        public  SelectList SurfaceMaterials{get;set;}
        private MegaDeskWeb.Models.MegaDeskWebContext _context;
        
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
            ShippingTypes = new List<SelectListItem>(){
                new SelectListItem{Value = "0", Text= "Standard Shipping"},
                new SelectListItem{Value = "3", Text="3-Day Shipping" },
                new SelectListItem{Value = "5", Text="5-Day Shipping"},
                new SelectListItem{Value = "7", Text="7-Day Shipping"}
            };
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
            DeskQuote = Calculations.PopulateQuote(DeskQuote, SelectedShip, localMaterialID, _context);
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}