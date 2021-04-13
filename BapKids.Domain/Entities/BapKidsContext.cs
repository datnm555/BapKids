namespace BapKids.Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BapKidsContext : DbContext
    {
        public BapKidsContext()
            : base("name=BapKidsContext1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("CategoryProducts").MapLeftKey("CategoryId").MapRightKey("ProductId"));
        }
    }
}
