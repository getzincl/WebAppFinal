using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MTHeadBrewery.Models;

namespace MTHeadBrewery.DAL
{
    public class BreweryContext : DbContext
    {

        public BreweryContext() : base("BreweryContext")
        {
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewed> Brewing { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
