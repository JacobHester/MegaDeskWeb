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
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb.Models.MegaDeskWebContext _context;

        public IndexModel(MegaDeskWeb.Models.MegaDeskWebContext context)
        {
            _context = context;
        }

        public IList<Desk> Desk { get;set; }

        public async Task OnGetAsync()
        {
            Desk = await _context.Desk
                .Include(d => d.SurfaceMaterial).ToListAsync();
        }
    }
}
