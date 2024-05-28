using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ro_VideoGameCatalogue.Models;

namespace Ro_VideoGameCatalogue.Data
{
    public class MVCVideogameContext : DbContext
    {
        public MVCVideogameContext (DbContextOptions<MVCVideogameContext> options)
            : base(options)
        {
        }

        public DbSet<Ro_VideoGameCatalogue.Models.Videogame> Videogame { get; set; } = default!;
    }
}
