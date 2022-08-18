using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class JRosasPublicisGroupContext : DbContext
    {
        public JRosasPublicisGroupContext()
        {
        }

        public JRosasPublicisGroupContext(DbContextOptions<JRosasPublicisGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Copy> Copys { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-9S059DSE; Database= JRosasPublicisGroup; Trusted_Connection=True; User ID=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alias");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.RefId).HasColumnName("ref_id");
            });

            modelBuilder.Entity<Copy>(entity =>
            {
                entity.ToTable("copys");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Anunciante)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("anunciante");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.File)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("file");

                entity.Property(e => e.Hora)
                    .HasColumnType("datetime")
                    .HasColumnName("hora");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Medio)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("medio")
                    .IsFixedLength();

                entity.Property(e => e.Processing).HasColumnName("processing");

                entity.Property(e => e.Producto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("producto");

                entity.Property(e => e.Programa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("programa");

                entity.Property(e => e.Tema)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tema");

                entity.Property(e => e.Vehiculo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("vehiculo");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("version");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Copies)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__copys__id_catego__1B0907CE");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("pages");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Medio)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("medio")
                    .IsFixedLength();

                entity.Property(e => e.Processing).HasColumnName("processing");

                entity.Property(e => e.Spots).HasColumnName("spots");

                entity.Property(e => e.SrcLink)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("src_link");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__pages__id_catego__1273C1CD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
