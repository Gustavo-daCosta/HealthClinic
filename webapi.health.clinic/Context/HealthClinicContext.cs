using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Context;

public partial class HealthClinicContext : DbContext
{
    public HealthClinicContext()
    {
    }

    public HealthClinicContext(DbContextOptions<HealthClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clinica> Clinica { get; set; }

    public virtual DbSet<Comentario> Comentario { get; set; }

    public virtual DbSet<Consulta> Consulta { get; set; }

    public virtual DbSet<Especialidade> Especialidade { get; set; }

    public virtual DbSet<Medico> Medico { get; set; }

    public virtual DbSet<Paciente> Paciente { get; set; }

    public virtual DbSet<Prontuario> Prontuario { get; set; }

    public virtual DbSet<TipoDeUsuario> TipoDeUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NOTE11-S14; initial catalog=HealthClinic; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;", x => x.UseDateOnlyTimeOnly());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinica>(entity =>
        {
            entity.HasKey(e => e.IdClinica).HasName("PK__Clinica__52A9095156A49794");

            entity.ToTable("Clinica");

            entity.HasIndex(e => e.RazaoSocial, "UQ__Clinica__448779F00B3578DB").IsUnique();

            entity.HasIndex(e => e.Cnpj, "UQ__Clinica__AA57D6B417739FC3").IsUnique();

            entity.Property(e => e.IdClinica).ValueGeneratedNever();
            entity.Property(e => e.Cnpj)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNPJ");
            entity.Property(e => e.Endereco)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PK__Comentar__DDBEFBF94585FE7B");

            entity.ToTable("Comentario");

            entity.Property(e => e.IdComentario).ValueGeneratedNever();
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__IdCon__693CA210");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("PK__Consulta__9B2AD1D82C25E94D");

            entity.Property(e => e.IdConsulta).ValueGeneratedNever();
            entity.Property(e => e.Data).HasColumnType("datetime");

            entity.HasOne(d => d.IdClinicaNavigation).WithMany(p => p.Consultas)
                .HasForeignKey(d => d.IdClinica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__IdClin__60A75C0F");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__IdMedi__619B8048");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consulta__IdPaci__628FA481");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidade).HasName("PK__Especial__5676CEFFC9EFD422");

            entity.ToTable("Especialidade");

            entity.HasIndex(e => e.TituloEspecialidade, "UQ__Especial__83ADECEAD4A8AD60").IsUnique();

            entity.Property(e => e.IdEspecialidade).ValueGeneratedNever();
            entity.Property(e => e.TituloEspecialidade)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__Medico__C326E652EE958E32");

            entity.ToTable("Medico");

            entity.HasIndex(e => e.Crm, "UQ__Medico__C1F887FF59368930").IsUnique();

            entity.Property(e => e.IdMedico).ValueGeneratedNever();
            entity.Property(e => e.Crm)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CRM");

            entity.HasOne(d => d.IdClinicaNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdClinica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medico__IdClinic__59FA5E80");

            entity.HasOne(d => d.IdEspecialidadeNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdEspecialidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medico__IdEspeci__59063A47");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medico__IdUsuari__5812160E");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49B016737C5");

            entity.ToTable("Paciente");

            entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F897310AB78CED").IsUnique();

            entity.Property(e => e.IdPaciente).ValueGeneratedNever();
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.DataNascimento).HasColumnType("date");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paciente__IdUsua__5DCAEF64");
        });

        modelBuilder.Entity<Prontuario>(entity =>
        {
            entity.HasKey(e => e.IdProntuario).HasName("PK__Prontuar__3AB81E66D1B9EFC7");

            entity.ToTable("Prontuario");

            entity.Property(e => e.IdProntuario).ValueGeneratedNever();
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descricao)
                .HasMaxLength(400)
                .IsUnicode(false);

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Prontuarios)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prontuari__IdCon__656C112C");
        });

        modelBuilder.Entity<TipoDeUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TipoDeUs__CA04062B9C257242");

            entity.ToTable("TipoDeUsuario");

            entity.Property(e => e.IdTipoUsuario).ValueGeneratedNever();
            entity.Property(e => e.TituloTipoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF978D831DA8");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Telefone, "UQ__Usuario__4EC504B67C853C9D").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534181F3B51").IsUnique();

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__IdTipoU__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
