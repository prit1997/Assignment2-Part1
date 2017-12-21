namespace Assignment2_Part1.Models
{
    using System.Data.Entity;

    public partial class AppleModel : DbContext
    {
        public AppleModel()
            : base("name=AppleModel1")
        {
        }

        public virtual DbSet<APPLE> APPLEs { get; set; }
        public virtual DbSet<IPHONE> IPHONEs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APPLE>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<APPLE>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<APPLE>()
                .Property(e => e.PROVINCE)
                .IsUnicode(false);

            modelBuilder.Entity<APPLE>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<APPLE>()
                .Property(e => e.CUSTOMER_CARE)
                .IsUnicode(false);

            modelBuilder.Entity<APPLE>()
                .Property(e => e.PRODUCTS)
                .IsUnicode(false);

            modelBuilder.Entity<APPLE>()
                .HasMany(e => e.IPHONEs)
                .WithRequired(e => e.APPLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IPHONE>()
                .Property(e => e.SERIAL_NO)
                .IsUnicode(false);

            modelBuilder.Entity<IPHONE>()
                .Property(e => e.PRODUCT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<IPHONE>()
                .Property(e => e.PRODUCT_SERIES)
                .IsUnicode(false);

            modelBuilder.Entity<IPHONE>()
                .Property(e => e.PRODUCT_STORAGE)
                .IsUnicode(false);

            modelBuilder.Entity<IPHONE>()
                .Property(e => e.PRODUCT_PROCESSOR)
                .IsUnicode(false);
        }
    }
}
