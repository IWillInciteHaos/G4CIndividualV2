using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrangesAndChocolate.Models;
using OrangesAndChocolateB.Models;

namespace OrangesAndChocolate
{
    public class OACDBContext : IdentityDbContext<SiteUser>
    {

        public OACDBContext(DbContextOptions<OACDBContext> options) : base(options)
        {


        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Ingredient>(i =>
            {
                i.HasKey(ing => ing.Id);
                i.HasOne(ing => ing.Recipe)
                    .WithMany(r => r.Ingredients)
                    .HasForeignKey(ing => ing.RecipieID);
            });

            mb.Entity<Recipe>(rec =>
            {
                rec.HasKey(r => r.ID);
                rec.HasMany(r => r.Ingredients)
                    .WithOne(i => i.Recipe);
            });

            base.OnModelCreating(mb);
        }
    }
}
