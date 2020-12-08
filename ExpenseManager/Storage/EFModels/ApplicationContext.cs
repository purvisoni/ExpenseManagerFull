using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ExpenseManager{

    public class ApplicationContext : IdentityDbContext<IdentityUser> {

        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base(options){
            //empty constructor
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        
        public DbSet<ExpenseDetailEF> ExpenseDetails { get; set;} 
    }
}