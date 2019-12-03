using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_TW.Models
{
    public partial class AgendaContext : DbContext
    {
        public AgendaContext()
        {
        }

        public AgendaContext(DbContextOptions<AgendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<TblAdm> TblAdm { get; set; }
        public virtual DbSet<TblComunidade> TblComunidade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-V5KAA8D\\SQLEXPRESS;Database=Agenda;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__CD54BC5A35C4BA1F");

                entity.Property(e => e.NomeCategoria).IsUnicode(false);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__evento__AF150CA5027BD988");

                entity.Property(e => e.Alimentaçao).IsFixedLength();

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Interprete).IsFixedLength();

                entity.Property(e => e.Localizacao).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Sala).IsFixedLength();

                entity.HasOne(d => d.IdAdmNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdAdm)
                    .HasConstraintName("FK__evento__id_adm__3F466844");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__evento__id_categ__3E52440B");

                entity.HasOne(d => d.IdComunidadeNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdComunidade)
                    .HasConstraintName("FK__evento__id_comun__3D5E1FD2");
            });

            modelBuilder.Entity<TblAdm>(entity =>
            {
                entity.HasKey(e => e.IdAdm)
                    .HasName("PK__tbl_adm__6BE8F80FF92A2E9C");

                entity.Property(e => e.EmailAdm).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.Property(e => e.TipoUsuario).IsFixedLength();
            });

            modelBuilder.Entity<TblComunidade>(entity =>
            {
                entity.HasKey(e => e.IdComunidade)
                    .HasName("PK__tbl_comu__842F2DBB42F46C1F");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.NomeComunidade).IsUnicode(false);

                entity.Property(e => e.NomeResponsavel).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
