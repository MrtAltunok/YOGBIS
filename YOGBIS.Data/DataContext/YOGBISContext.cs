﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YOGBIS.Data.DbModels;

namespace YOGBIS.Data.DataContext
{
    public class YOGBISContext : IdentityDbContext
    {
        public YOGBISContext(DbContextOptions options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            base.OnModelCreating(builder.EnableAutoHistory(null));

            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(127));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.ConcurrencyStamp).HasColumnType("varchar(256)"));

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.ProviderKey).HasMaxLength(127);
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.RoleId).HasMaxLength(127);
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.Name).HasMaxLength(127);
            });

            #region Kıtalar
            builder.Entity<Kitalar>().HasData(
        new Kitalar()
        { KitaId = 1, KitaAdi = "Afrika", KitaAciklama = "Afrika Kıtası" },
        new Kitalar()
        { KitaId = 2, KitaAdi = "Antartika", KitaAciklama = "Antartika Kıtası" },
        new Kitalar()
        { KitaId = 3, KitaAdi = "Asya", KitaAciklama = "Asya Kıtası" },
        new Kitalar()
        { KitaId = 4, KitaAdi = "Avrupa", KitaAciklama = "Avrupa Kıtası" },
        new Kitalar()
        { KitaId = 5, KitaAdi = "Avustralya", KitaAciklama = "Avustralya Kıtası" },
        new Kitalar()
        { KitaId = 6, KitaAdi = "Güney Amerika", KitaAciklama = "Güney Amerika Kıtası" },
        new Kitalar()
        { KitaId = 7, KitaAdi = "Kuzey Amerika", KitaAciklama = "Kuzey Amerika Kıtası" }
        );
            #endregion

            #region FP
            builder.Entity<SoruKategori>()
        .HasKey(o => new { o.SoruId, o.KategoriId });

            builder.Entity<SoruDerece>()
                .HasKey(o => new { o.SoruId, o.DereceId });

            builder.Entity<UlkeGruplariKitalar>()
                .HasKey(o => new { o.KitaId, o.UlkeGrupId });

            builder.Entity<GorevKaydi>()
                .HasKey(o => new { o.GorevId, o.GorevliTC });

            builder.Entity<SoruDerece>()
                .HasOne<SoruBankasi>(s => s.SoruBankasi)
                .WithMany(g => g.SoruDereces)
                .HasForeignKey(f => f.SoruId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SoruDerece>()
                .HasOne<Dereceler>(s => s.Dereceler)
                .WithMany(g => g.SoruDereces)
                .HasForeignKey(f => f.SoruId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SoruKategori>()
                .HasOne<SoruBankasi>(s => s.SoruBankasi)
                .WithMany(g => g.SoruKategoris)
                .HasForeignKey(f => f.SoruId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SoruKategori>()
                .HasOne<SoruKategoriler>(s => s.SoruKategoriler)
                .WithMany(g => g.SoruKategoris)
                .HasForeignKey(f => f.KategoriId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UlkeGruplariKitalar>()
                .HasOne<Kitalar>(s => s.Kitalar)
                .WithMany(g => g.UlkeGruplariKitalars)
                .HasForeignKey(f => f.KitaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UlkeGruplariKitalar>()
                .HasOne<UlkeGruplari>(s => s.UlkeGruplari)
                .WithMany(g => g.UlkeGruplariKitalars)
                .HasForeignKey(f => f.UlkeGrupId)
                .OnDelete(DeleteBehavior.Cascade); 
            #endregion
        }

        #region DbSets
        public DbSet<Adaylar> Adaylars { get; set; }
        public DbSet<Dereceler> Derecelers { get; set; }
        public DbSet<Eyaletler> Eyaletlers { get; set; }
        public DbSet<GorevKaydi> GorevKaydis { get; set; }
        public DbSet<Kitalar> Kitalars { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Mulakatlar> Mulakatlars { get; set; }
        public DbSet<MulakatSorulari> MulakatSorularis { get; set; }
        public DbSet<Notlar> Notlars { get; set; }
        public DbSet<Ogrenciler> Ogrencilers { get; set; }
        public DbSet<Ogretmenler> Ogretmenlers { get; set; }
        public DbSet<OkulBilgi> OkulBilgis { get; set; } // geçici tablo
        public DbSet<Okullar> Okullars { get; set; }
        public DbSet<Okutmanlar> Okutmanlars { get; set; }
        public DbSet<Sehirler> Sehirlers { get; set; }
        public DbSet<Siniflar> Siniflars { get; set; }
        public DbSet<SoruBankasi> SoruBankasis { get; set; }
        public DbSet<SoruDerece> SoruDereces { get; set; }
        public DbSet<SoruKategori> SoruKategoris { get; set; }
        public DbSet<SoruKategoriler> SoruKategorilers { get; set; }
        public DbSet<Subeler> Subelers { get; set; }
        public DbSet<UlkeGruplari> UlkeGruplaris { get; set; }
        public DbSet<UlkeGruplariKitalar> UlkeGruplariKitalars { get; set; }
        public DbSet<Ulkeler> Ulkelers { get; set; }
        public DbSet<Universiteler> Universitelers { get; set; }        

        #endregion
    }
}
