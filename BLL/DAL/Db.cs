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

    public virtual DbSet<category> categories { get; set; }

    public virtual DbSet<city> cities { get; set; }

    public virtual DbSet<country> countries { get; set; }

    public virtual DbSet<product> products { get; set; }

    public virtual DbSet<productstore> productstores { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<store> stores { get; set; }

    public virtual DbSet<user> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("categories_pkey");
        });

        modelBuilder.Entity<city>(entity =>
        {
            entity.HasKey(e => e.id).HasName("cities_pkey");

            entity.HasOne(d => d.country).WithMany(p => p.cities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cities_countryid_fkey");
        });

        modelBuilder.Entity<country>(entity =>
        {
            entity.HasKey(e => e.id).HasName("countries_pkey");
        });

        modelBuilder.Entity<product>(entity =>
        {
            entity.HasKey(e => e.id).HasName("products_pkey");

            entity.HasOne(d => d.category).WithMany(p => p.products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_categoryid_fkey");
        });

        modelBuilder.Entity<productstore>(entity =>
        {
            entity.HasKey(e => e.id).HasName("productstores_pkey");

            entity.HasOne(d => d.product).WithMany(p => p.productstores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productstores_productid_fkey");

            entity.HasOne(d => d.store).WithMany(p => p.productstores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productstores_storeid_fkey");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.id).HasName("roles_pkey");
        });

        modelBuilder.Entity<store>(entity =>
        {
            entity.HasKey(e => e.id).HasName("stores_pkey");

            entity.HasOne(d => d.city).WithMany(p => p.stores).HasConstraintName("stores_cityid_fkey");

            entity.HasOne(d => d.country).WithMany(p => p.stores).HasConstraintName("stores_countryid_fkey");
        });

        modelBuilder.Entity<user>(entity =>
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
