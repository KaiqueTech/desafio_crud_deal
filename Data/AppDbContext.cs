
using CursosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CursosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AlunoModel> Alunos {get; set;}
        public DbSet<CursoModel> Cursos {get; set;}
        public DbSet<MatriculaModel> Matriculas {get; set;}

       protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoModel>(entity =>
            {
                entity.ToTable("tbl_Aluno");

                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).ValueGeneratedOnAdd();

                entity.Property(a => a.Nome)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(a => a.Email)
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(a => a.DataNascimento)
                    .IsRequired();

                entity.Property(a => a.Ativo)
                    .IsRequired();

                entity.HasIndex(a => a.Email)
                    .IsUnique();
            });

            builder.Entity<CursoModel>(entity =>
            {
                entity.ToTable("tbl_Curso");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Titulo)
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(c => c.CargaHoraria)
                    .IsRequired();

                entity.Property(c => c.Ativo)
                    .IsRequired();
            });

            builder.Entity<MatriculaModel>(entity =>
            {
                entity.ToTable("tbl_Matricula");

                entity.HasKey(m => m.Id);

                entity.Property(m => m.DataMatricula)
                    .IsRequired();

                entity.HasOne(m => m.Aluno)
                    .WithMany(a => a.Matriculas)
                    .HasForeignKey(m => m.AlunoId);

                entity.HasOne(m => m.Curso)
                    .WithMany(c => c.Matriculas)
                    .HasForeignKey(m => m.CursoId);
            });
        }
    }
}
