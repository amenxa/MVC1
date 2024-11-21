using Microsoft.EntityFrameworkCore;

namespace mvcapl1.Models.Data
{ 
    public class AppDpContext :DbContext
    {
        public AppDpContext(DbContextOptions<AppDpContext>options ): base  (options) 
        {
                
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
