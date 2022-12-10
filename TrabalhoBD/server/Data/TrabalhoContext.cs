using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using TrabalhoBd.Models.Trabalho;

namespace TrabalhoBd.Data
{
  public partial class TrabalhoContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public TrabalhoContext(DbContextOptions<TrabalhoContext> options):base(options)
    {
    }

    public TrabalhoContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TrabalhoBd.Models.Trabalho.AreaCientifica>().HasNoKey();
        builder.Entity<TrabalhoBd.Models.Trabalho.Contem>().HasNoKey();
        builder.Entity<TrabalhoBd.Models.Trabalho.KeyWord>().HasNoKey();
        builder.Entity<TrabalhoBd.Models.Trabalho.PatrocinaPrograma>().HasNoKey();
        builder.Entity<TrabalhoBd.Models.Trabalho.PatrocinadorPrivado>().HasNoKey();
        builder.Entity<TrabalhoBd.Models.Trabalho.Pertence1>().HasNoKey();
        builder.Entity<TrabalhoBd.Models.Trabalho.Pertence2>().HasNoKey();
        builder.Entity<TrabalhoBd.Models.Trabalho.Publicacao>().HasNoKey();
        builder.Entity<TrabalhoBd.Models.Trabalho.Responsavel>().HasNoKey();


        builder.Entity<TrabalhoBd.Models.Trabalho.Projeto>()
              .Property(p => p.Data_Init)
              .HasColumnType("date");

        builder.Entity<TrabalhoBd.Models.Trabalho.Projeto>()
              .Property(p => p.Data_Fin)
              .HasColumnType("date");

        builder.Entity<TrabalhoBd.Models.Trabalho.AreaCientifica>()
              .Property(p => p.ID_Projeto)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Contem>()
              .Property(p => p.ID_Projeto)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Contem>()
              .Property(p => p.ID_Investigador)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Contem>()
              .Property(p => p.Tempo_Gasto)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Contem>()
              .Property(p => p.Tempo_Limite)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Instituicao>()
              .Property(p => p.ID)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Instituicao>()
              .Property(p => p.Tel)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Investigador>()
              .Property(p => p.ID)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Investigador>()
              .Property(p => p.Num_Funcionario)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Investigador>()
              .Property(p => p.ID_Instituicao)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Investigador>()
              .Property(p => p.Tempo_Total)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.KeyWord>()
              .Property(p => p.ID_Projeto)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.PatrocinaPrograma>()
              .Property(p => p.ID_Programa_Patrocinador)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.PatrocinaPrograma>()
              .Property(p => p.ID_Projeto)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.PatrocinaPrograma>()
              .Property(p => p.Montante)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Patrocinador>()
              .Property(p => p.ID)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Patrocinador>()
              .Property(p => p.Tel)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.PatrocinadorPrivado>()
              .Property(p => p.ID_Patrocinador)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.PatrocinadorPrivado>()
              .Property(p => p.ID_Projeto)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.PatrocinadorPrivado>()
              .Property(p => p.Montante)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.PatrocinioPublico>()
              .Property(p => p.ID)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.PatrocinioPublico>()
              .Property(p => p.Tel)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Pertence1>()
              .Property(p => p.ID_Investigador)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Pertence1>()
              .Property(p => p.ID_UC)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Pertence1>()
              .Property(p => p.ID_Projeto)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Pertence2>()
              .Property(p => p.ID_UC)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Pertence2>()
              .Property(p => p.ID_Projeto)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Projeto>()
              .Property(p => p.ID)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Projeto>()
              .Property(p => p.ID_UC)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Projeto>()
              .Property(p => p.Max_Cost)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Projeto>()
              .Property(p => p.Total_Cost)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Projeto>()
              .Property(p => p.ID_IR)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Publicacao>()
              .Property(p => p.ID_Projeto)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Publicacao>()
              .Property(p => p.ID_Investigador)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Responsavel>()
              .Property(p => p.ID_Investigador)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Responsavel>()
              .Property(p => p.ID_Projeto)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.Responsavel>()
              .Property(p => p.Tempo_Responsavel)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.UnidadeCurricular>()
              .Property(p => p.ID)
              .HasPrecision(10, 0);

        builder.Entity<TrabalhoBd.Models.Trabalho.UnidadeCurricular>()
              .Property(p => p.ID_Instituicao)
              .HasPrecision(10, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<TrabalhoBd.Models.Trabalho.AreaCientifica> AreaCientificas
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.Contem> Contems
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.Instituicao> Instituicaos
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.Investigador> Investigadors
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.KeyWord> KeyWords
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.PatrocinaPrograma> PatrocinaProgramas
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.Patrocinador> Patrocinadors
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.PatrocinadorPrivado> PatrocinadorPrivados
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.PatrocinioPublico> PatrocinioPublicos
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.Pertence1> Pertence1s
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.Pertence2> Pertence2s
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.Projeto> Projetos
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.Publicacao> Publicacaos
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.Responsavel> Responsavels
    {
      get;
      set;
    }

    public DbSet<TrabalhoBd.Models.Trabalho.UnidadeCurricular> UnidadeCurriculars
    {
      get;
      set;
    }
  }
}
