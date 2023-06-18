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

    public virtual DbSet<Experience> Experiences { get; set; }
    
    public virtual DbSet<Proposta> Propostas { get; set; }
    
    public virtual DbSet<Categoria> Categorias { get; set; }
    
    public virtual DbSet<Company> Companies { get; set; }

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
            entity.HasKey(e => e.Id).HasName("id");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.PrHora).HasColumnName("pr_hora");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdExperience).HasColumnName("id_xp");
            entity.Property(e => e.Country).HasColumnName("country");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("id");

            entity.ToTable("company");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });
        
        modelBuilder.Entity<Proposta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("id");

            entity.ToTable("proposta");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.IdCompany).HasColumnName("id_company");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.IdCategoria).HasColumnName("id_cat");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
        });
        
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("id");

            entity.ToTable("categoria");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });
        
        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("id");

            entity.ToTable("experience");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.IdCompany).HasColumnName("id_company");
            entity.Property(e => e.AnoIni).HasColumnName("ano_ini");
            entity.Property(e => e.AnoFim).HasColumnName("ano_fim");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
