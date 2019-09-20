namespace StokTakip.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StokDbEntities : DbContext
    {
        public StokDbEntities()
            : base("name=StokDbEntities1")
        {
        }

        public virtual DbSet<TBLKATEGORILER> TBLKATEGORILER { get; set; }
        public virtual DbSet<TBLMUSTERILER> TBLMUSTERILER { get; set; }
        public virtual DbSet<TBLTESLIMAT> TBLTESLIMAT { get; set; }
        public virtual DbSet<TBLURUNLER> TBLURUNLER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBLKATEGORILER>()
                .Property(e => e.KATEGORIAD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLKATEGORILER>()
                .HasMany(e => e.TBLURUNLER)
                .WithOptional(e => e.TBLKATEGORILER)
                .HasForeignKey(e => e.URUNKATEGORI);

            modelBuilder.Entity<TBLMUSTERILER>()
                .Property(e => e.MUSTERIAD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLMUSTERILER>()
                .Property(e => e.MUSTERISOYAD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLMUSTERILER>()
                .HasMany(e => e.TBLTESLIMAT)
                .WithOptional(e => e.TBLMUSTERILER)
                .HasForeignKey(e => e.MUSTERI);

            modelBuilder.Entity<TBLURUNLER>()
                .Property(e => e.URUNAD)
                .IsUnicode(false);

            modelBuilder.Entity<TBLURUNLER>()
                .Property(e => e.MARKA)
                .IsUnicode(false);

            modelBuilder.Entity<TBLURUNLER>()
                .HasMany(e => e.TBLTESLIMAT)
                .WithOptional(e => e.TBLURUNLER)
                .HasForeignKey(e => e.URUN);
        }
    }
}
