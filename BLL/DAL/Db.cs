using System;
using System.Collections.Generic;
using BLL.DAL;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL;

public partial class Db : DbContext
{
    public Db(DbContextOptions<Db> options)
        : base(options)
    {
    }

    public virtual DbSet<categories> categories { get; set; }

    public virtual DbSet<cities> cities { get; set; }

    public virtual DbSet<countries> countries { get; set; }

    public virtual DbSet<products> products { get; set; }

    public virtual DbSet<productstores> productstores { get; set; }

    public virtual DbSet<roles> roles { get; set; }

    public virtual DbSet<stores> stores { get; set; }

    public virtual DbSet<users> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<categories>(entity =>
        {
            entity.HasKey(e => e.id).HasName("categories_pkey");
        });

        modelBuilder.Entity<cities>(entity =>
        {
            entity.HasKey(e => e.id).HasName("cities_pkey");

            entity.HasOne(d => d.country).WithMany(p => p.cities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cities_countryid_fkey");
        });

        modelBuilder.Entity<countries>(entity =>
        {
            entity.HasKey(e => e.id).HasName("countries_pkey");
        });

        modelBuilder.Entity<products>(entity =>
        {
            entity.HasKey(e => e.id).HasName("products_pkey");

            entity.HasOne(d => d.category).WithMany(p => p.products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_categoryid_fkey");
        });

        modelBuilder.Entity<productstores>(entity =>
        {
            entity.HasKey(e => e.id).HasName("productstores_pkey");

            entity.HasOne(d => d.product).WithMany(p => p.productstores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productstores_productid_fkey");

            entity.HasOne(d => d.store).WithMany(p => p.productstores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productstores_storeid_fkey");
        });

        modelBuilder.Entity<roles>(entity =>
        {
            entity.HasKey(e => e.id).HasName("roles_pkey");
        });

        modelBuilder.Entity<stores>(entity =>
        {
            entity.HasKey(e => e.id).HasName("stores_pkey");

            entity.HasOne(d => d.city).WithMany(p => p.stores).HasConstraintName("stores_cityid_fkey");

            entity.HasOne(d => d.country).WithMany(p => p.stores).HasConstraintName("stores_countryid_fkey");
        });

        modelBuilder.Entity<users>(entity =>
        {
            entity.HasKey(e => e.id).HasName("users_pkey");

            entity.HasOne(d => d.role).WithMany(p => p.users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_roleid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
