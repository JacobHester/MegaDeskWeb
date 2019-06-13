using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages.Desks
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWeb.Models.MegaDeskWebContext _context;

        public DetailsModel(MegaDeskWeb.Models.MegaDeskWebContext context)
        {
            _context = context;
        }

        public Desk Desk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Desk = await _context.Desk
                .Include(d => d.SurfaceMaterial).FirstOrDefaultAsync(m => m.DeskID == id);

            if (Desk == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
