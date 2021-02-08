using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace T28_API_JWT_Ex1.Models
{
    public partial class T28API_JWT_Ex1Context : DbContext
    {
        public T28API_JWT_Ex1Context(DbContextOptions<T28API_JWT_Ex1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Piezas> Piezas { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Suministra> Suministra { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Piezas>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__PIEZAS__06370DAD0F01A77F");

                entity.ToTable("PIEZAS");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.ToTable("PROVEEDORES");

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Suministra>(entity =>
            {
                entity.HasKey(e => new { e.CodigoPieza, e.IdProveedor })
                    .HasName("PK_Suministra");

                entity.ToTable("SUMINISTRA");

                entity.Property(e => e.IdProveedor)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CodigoPiezaNavigation)
                    .WithMany(p => p.Suministra)
                    .HasForeignKey(d => d.CodigoPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SUMINISTR__Codig__3A81B327");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Suministra)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SUMINISTR__IdPro__3B75D760");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C920B56D1");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
