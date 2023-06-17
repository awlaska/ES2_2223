using System;
using System.Collections.Generic;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Context;

public partial class ES2DbContext : DbContext
{
    public ES2DbContext()
    {
    }

    public ES2DbContext(DbContextOptions<ES2DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Experiencia> Experiencias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=es2;Username=es2;Password=es2;SearchPath=public;Port=15432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("postgis")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("topology", "postgis_topology");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("authors_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.pr_hora).HasColumnName("pr_hora");
            entity.Property(e => e.name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.email)
                .HasMaxLength(100)
                .HasColumnName("email");
        });

        modelBuilder.Entity<Experiencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_pkey");

            entity.ToTable("experiencias");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.titulo).HasColumnName("Titulo");
            entity.Property(e => e.ano_ini).HasColumnName("ano_ini");
            entity.Property(e => e.ano_fim)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.empresa)
                .HasMaxLength(255)
                .HasColumnName("Empresa");

            entity.HasOne(d => d.User).WithMany(p => p.Experiencias)
                .HasForeignKey(d => d.User)
                .HasConstraintName("books_author_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
