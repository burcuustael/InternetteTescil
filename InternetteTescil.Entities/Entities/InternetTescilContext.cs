using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InternetteTescil.Entities.Entities;

public partial class InternetTescilContext : DbContext
{
    public InternetTescilContext()
    {
    }

    public InternetTescilContext(DbContextOptions<InternetTescilContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Costumer> Costumers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=InternetTescil;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Costumer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Costumer__3214EC275443A618");

            entity.ToTable("Costumer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Cellno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CELLNO");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Taxno)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TAXNO");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC274BC6E08C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderEMail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ORDER_E_MAIL");
            entity.Property(e => e.Orderdate)
                .HasColumnType("date")
                .HasColumnName("ORDERDATE");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Costumer1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
