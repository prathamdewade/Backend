using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Stylo_Spin.Models;

public partial class StylospinContext : DbContext
{
    public StylospinContext()
    {
    }

    public StylospinContext(DbContextOptions<StylospinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AboutU> AboutUs { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblContactU> TblContactUs { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblSlider> TblSliders { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PRATHAM\\SQLEXPRESS;Database=stylospin;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AboutU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AboutUs__3214EC07A117D9D6");
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__tblCateg__A9FDEC3260DAA25C");

            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<TblContactU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblConta__3214EC07E75BA7C3");
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCusto__3214EC0701839AFA");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.OId).HasName("PK__tblOrder__5AAB0C38F73010B2");

            entity.Property(e => e.OrdaerDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PaymentStatus).HasDefaultValue("Pending");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.TblOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblOrder_tblCustomer");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.TblOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblOrder_tblProduct");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__tblProdu__82E37F4986C47A31");

            entity.ToTable("tblProduct", tb => tb.HasTrigger("trg_UpdateStatusBasedOnQuantity"));

            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.TblProducts).HasConstraintName("FK_tblProduct_tblCategory");
        });

        modelBuilder.Entity<TblSlider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblSlide__3214EC075D7A54D3");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3213E83F5EB91795");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
