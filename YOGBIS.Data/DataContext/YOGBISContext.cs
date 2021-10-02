﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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

            builder.Entity<Kitalar>().HasData(
                new Kitalar() 
                { KitaId = 1, KitaAdi = "Afrika", KitaAciklama = "Afrika Kıtası"},
                new Kitalar()
                { KitaId = 2, KitaAdi = "Antartika", KitaAciklama = "Antartika Kıtası"},
                new Kitalar()
                { KitaId = 3, KitaAdi = "Asya", KitaAciklama = "Asya Kıtası"},
                new Kitalar()
                { KitaId = 4, KitaAdi = "Avrupa", KitaAciklama = "Avrupa Kıtası"},
                new Kitalar()
                { KitaId = 5, KitaAdi = "Avustralya", KitaAciklama = "Avustralya Kıtası"},
                new Kitalar()
                { KitaId = 6, KitaAdi = "Güney Amerika", KitaAciklama = "Güney Amerika Kıtası"},
                new Kitalar()
                { KitaId = 7, KitaAdi = "Kuzey Amerika", KitaAciklama = "Kuzey Amerika Kıtası"}
                );
        }

        #region DbSetler
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Eyaletler> Eyaletlers { get; set; }
        public DbSet<Kitalar> Kitalars { get; set; }
        public DbSet<UlkeGruplari> UlkeGruplaris { get; set; }
        public DbSet<Ulkeler> Ulkelers { get; set; }
        public DbSet<Sehirler> Sehirlers { get; set; }
        public DbSet<Mulakatlar> Mulakatlars { get; set; }
        public DbSet<MulakatSorulari> MulakatSorularis { get; set; }
        public DbSet<SoruBankasi> SoruBankasis { get; set; }        
        public DbSet<SoruKategori> SoruKategoris { get; set; }
        public DbSet<SoruKategoriler> SoruKategorilers { get; set; }
        public DbSet<UlkeGruplariKitalar> UlkeGruplariKitalars { get; set; }
        public DbSet<Gecmis> Gecmiss { get; set; }
        public DbSet<Dereceler> Derecelers { get; set; }

        #endregion
    }
}
