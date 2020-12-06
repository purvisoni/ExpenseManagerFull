using Microsoft.EntityFrameworkCore;

namespace ExpenseManager{

    public class ApplicationContext : DbContext {

        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base(options){
            //empty constructor
        }
        public DbSet<ExpenseDetailEF> ExpenseDetails { get; set;} 
    }
}