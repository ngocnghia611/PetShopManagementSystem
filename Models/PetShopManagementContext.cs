using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PetShopManagementSystem.Models;

public partial class PetShopManagementContext : DbContext
{
    public PetShopManagementContext()
    {
    }

    public PetShopManagementContext(DbContextOptions<PetShopManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NGOCNGHIA;Database=PetShopManagement;User Id=sa;Password=06112002;Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bill__11F2FC4ADD8DBCD3");

            entity.ToTable("Bill");

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Cust).WithMany(p => p.Bills)
                .HasForeignKey(d => d.CustId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bill__CustID__2A4B4B5E");

            entity.HasOne(d => d.Emp).WithMany(p => p.Bills)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bill__EmpID__2B3F6F97");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__Customer__049E3A892CEBF69B");

            entity.ToTable("Customer");

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.CustAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBA7984A10DC9");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EmpAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpDob).HasColumnName("EmpDOB");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpPass)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmpPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30CF86700E4");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Bill).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__BillI__2E1BDC42");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__2F10007B");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED153A3D55");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
