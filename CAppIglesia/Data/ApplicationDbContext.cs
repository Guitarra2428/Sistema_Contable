using CAppIglesia.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAppIglesia.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Registros> Registros { get; set; }
        public DbSet<Ofrendas> Ofrendas{ get; set; }
        public DbSet<Slider> Sliders{ get; set; }

        public DbSet<PagoDeServicios> pagoDeServicios { get; set; }


    }
}
