using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb;

namespace MegaDeskWeb.Models
{
    public class MegaDeskWebContext : DbContext
    {
        public MegaDeskWebContext (DbContextOptions<MegaDeskWebContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskWeb.DeskQuote> DeskQuote { get; set; }

        public DbSet<MegaDeskWeb.Desk> Desk { get; set; }
    }
}
