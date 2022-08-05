using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerRachunkow.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<Bill> Bill { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new InformationConfiguration());
            builder.ApplyConfiguration(new BillConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
