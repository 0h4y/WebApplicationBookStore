using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplicationBookStore.Models;

namespace WebApplicationBookStore.Data;

public partial class BookstoreContext : DbContext
{
    public BookstoreContext()
    {
    }

    public BookstoreContext(DbContextOptions<BookstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderRow> OrderRows { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<TitlarPerFörfattare> TitlarPerFörfattares { get; set; }

    public virtual DbSet<Writer> Writers { get; set; }

    public virtual DbSet<ÖvrigaTabeller> ÖvrigaTabellers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasMany(d => d.Writers).WithMany(p => p.Isbns)
                .UsingEntity<Dictionary<string, object>>(
                    "BooksWriter",
                    r => r.HasOne<Writer>().WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_BooksWriters_Writers"),
                    l => l.HasOne<Book>().WithMany()
                        .HasForeignKey("Isbn")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_BooksWriters_Books"),
                    j =>
                    {
                        j.HasKey("Isbn", "WriterId").HasName("PK_BooksWriters_1");
                    });
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasMany(d => d.Adresses).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomersAdress",
                    r => r.HasOne<Adress>().WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomersAdresses_Adresses"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomersAdresses_Customers"),
                    j =>
                    {
                        j.HasKey("CustomerId", "AdressId").HasName("PK_CustomersAdresses_1");
                    });

            entity.HasMany(d => d.Phones).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomersPhone",
                    r => r.HasOne<Phone>().WithMany()
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomersPhones_Phones"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomersPhones_Customers"),
                    j =>
                    {
                        j.HasKey("CustomerId", "PhoneId").HasName("PK_CustomersPhones_1");
                    });
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.Inventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventories_Books");

            entity.HasOne(d => d.Store).WithMany(p => p.Inventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventories_Stores");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.DateTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Store).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Stores");
        });

        modelBuilder.Entity<OrderRow>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.Isbn }).HasName("PK_OrderRows_1");

            entity.Property(e => e.Amount).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.OrderRows)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderRows_Books");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderRows)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderRows_Orders");
        });

        modelBuilder.Entity<TitlarPerFörfattare>(entity =>
        {
            entity.ToView("TitlarPerFörfattare");
        });

        modelBuilder.Entity<Writer>(entity =>
        {
            entity.Property(e => e.AgeCalculated).HasComputedColumnSql("(case when [DeathDate] IS NOT NULL then floor(datediff(day,[BirthDate],[DeathDate])/(365)) else floor(datediff(day,[BirthDate],getdate())/(365)) end)", false);
        });

        modelBuilder.Entity<ÖvrigaTabeller>(entity =>
        {
            entity.ToView("ÖvrigaTabeller");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
