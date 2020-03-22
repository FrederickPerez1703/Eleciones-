using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Elecciones_itla.Models
{
    public partial class Final_EleccionContext : DbContext
    {
        public Final_EleccionContext()
        {
        }

        public Final_EleccionContext(DbContextOptions<Final_EleccionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Candidatos> Candidatos { get; set; }
        public virtual DbSet<Ciudadanos> Ciudadanos { get; set; }
        public virtual DbSet<Elecciones> Elecciones { get; set; }
        public virtual DbSet<Partidos> Partidos { get; set; }
        public virtual DbSet<PuestoElectivo> PuestoElectivo { get; set; }
        public virtual DbSet<Votos> Votos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-CGRM0AKG;Database=Final_Eleccion;persist security info=true;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK_ADMINISTRADOR");

                entity.ToTable("administrador");

                entity.Property(e => e.IdAdministrador).HasColumnName("Id_administrador");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Candidatos>(entity =>
            {
                entity.HasKey(e => e.IdCandidato)
                    .HasName("PK_ID_CANDIDATOS");

                entity.Property(e => e.IdCandidato).HasColumnName("Id_candidato");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Foto).HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PartidoCanId).HasColumnName("PartidoCan_id");

                entity.Property(e => e.PuestoCanId).HasColumnName("PuestoCan_id");

                entity.HasOne(d => d.PartidoCan)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.PartidoCanId)
                    .HasConstraintName("FK_CANDIDATO_PARTIDO");

                entity.HasOne(d => d.PuestoCan)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.PuestoCanId)
                    .HasConstraintName("FK_CANDIDATOS_PUESTO");
            });

            modelBuilder.Entity<Ciudadanos>(entity =>
            {
                entity.HasKey(e => e.IdCiudadano)
                    .HasName("PK_ID_CIUDADANO");

                entity.Property(e => e.IdCiudadano).HasColumnName("Id_ciudadano");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PartidoCiuId).HasColumnName("PartidoCiu_id");

                entity.HasOne(d => d.PartidoCiu)
                    .WithMany(p => p.Ciudadanos)
                    .HasForeignKey(d => d.PartidoCiuId)
                    .HasConstraintName("FK_CIUDADANOS_PARTIDO");
            });

            modelBuilder.Entity<Elecciones>(entity =>
            {
                entity.HasKey(e => e.IdEleccion)
                    .HasName("PK_ID_ELECCIONES");

                entity.Property(e => e.IdEleccion).HasColumnName("Id_eleccion");

                entity.Property(e => e.FechaRealizada)
                    .HasColumnName("Fecha_Realizada")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Partidos>(entity =>
            {
                entity.HasKey(e => e.IdPartido)
                    .HasName("PK_ID_PATRTIDO");

                entity.Property(e => e.IdPartido).HasColumnName("Id_partido");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EleccionesId).HasColumnName("Elecciones_id");

                entity.Property(e => e.Logo).HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Elecciones)
                    .WithMany(p => p.Partidos)
                    .HasForeignKey(d => d.EleccionesId)
                    .HasConstraintName("FK_PARTIDOS_ELECCIONES");
            });

            modelBuilder.Entity<PuestoElectivo>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PK_ID_PUESTO");

                entity.ToTable("Puesto_Electivo");

                entity.Property(e => e.IdPuesto).HasColumnName("Id_puesto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PartidoPuesId).HasColumnName("PartidoPues_id");

                entity.HasOne(d => d.PartidoPues)
                    .WithMany(p => p.PuestoElectivo)
                    .HasForeignKey(d => d.PartidoPuesId)
                    .HasConstraintName("FK_PUESTO_ELECTIVO_PARTIDO");
            });

            modelBuilder.Entity<Votos>(entity =>
            {
                entity.HasKey(e => new { e.IdCiudadanoVoto, e.IdCandidatoVoto })
                    .HasName("PK_CIUDADANO_VOTO");

                entity.Property(e => e.IdCiudadanoVoto).HasColumnName("Id_ciudadano_voto");

                entity.Property(e => e.IdCandidatoVoto).HasColumnName("Id_candidato_voto");

                entity.HasOne(d => d.IdCandidatoVotoNavigation)
                    .WithMany(p => p.Votos)
                    .HasForeignKey(d => d.IdCandidatoVoto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CANDIDATO_VOTOS");

                entity.HasOne(d => d.IdCiudadanoVotoNavigation)
                    .WithMany(p => p.Votos)
                    .HasForeignKey(d => d.IdCiudadanoVoto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VOTOS");
            });
        }
    }
}
