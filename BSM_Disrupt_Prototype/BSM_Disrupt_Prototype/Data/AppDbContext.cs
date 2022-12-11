using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSM_Disrupt_Prototype.Data
{
	public class AppDbContext : IdentityDbContext<ApplicationUser>
	{
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}

