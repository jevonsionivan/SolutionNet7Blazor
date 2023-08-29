using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Models;

public partial class DbcrudBlazorContext : DbContext
{
    public DbcrudBlazorContext()
    {
    }

    public DbcrudBlazorContext(DbContextOptions<DbcrudBlazorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblMenuMakanan> TblMenuMakanans { get; set; }

    public virtual DbSet<TblPesanan> TblPesanans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblMenuMakanan>(entity =>
        {
            entity.HasKey(e => e.IdMenuMakanan).HasName("PK__Tbl_Menu__02BD53673F759E20");

            entity.ToTable("Tbl_MenuMakanan");

            entity.Property(e => e.Harga).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nama)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblPesanan>(entity =>
        {
            entity.HasKey(e => e.IdPesanan).HasName("PK__Tbl_Pesa__F186C670401E0775");

            entity.ToTable("Tbl_Pesanan");

            entity.Property(e => e.Harga).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Jumlah).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NamaCustomer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NoPesanan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TglPesanan).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdMenuMakananNavigation).WithMany(p => p.TblPesanans)
                .HasForeignKey(d => d.IdMenuMakanan)
                .HasConstraintName("FK__Tbl_Pesan__IdMen__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
