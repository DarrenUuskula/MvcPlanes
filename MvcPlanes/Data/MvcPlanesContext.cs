using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcPlanes.Models;

namespace MvcPlanes.Data
{
    public class MvcPlanesContext : DbContext
    {
        public MvcPlanesContext (DbContextOptions<MvcPlanesContext> options)
            : base(options)
        {
        }

        public DbSet<MvcPlanes.Models.Plane> Planes { get; set; }
    }
}
