using GraphQL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }


        public virtual DbSet<ItemData> Items { get; set; }
        public virtual DbSet<ItemList> ItemLists { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ItemData>(entity =>
            {
                entity.HasOne(d => d.ItemList)
                    .WithMany(p => p.ItemDataList)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ItemData_ItemList");
            });
        }


    }
}
