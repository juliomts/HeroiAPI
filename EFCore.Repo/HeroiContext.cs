using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repo
{
    public class HeroiContext : DbContext //Deve-se instalar o pacote do Entity e o design novamente
    {                                     //Dependências -> Adicionar pacote

        public HeroiContext(DbContextOptions<HeroiContext> options) : base (options) //Tá passando como parametro para esse construtor um DbContext options que referencia
                                                                                     //O HeroiContext no Startup, e essa options será passsada para a (base), ou seja
                                                                                     //O contrutor da classe base(DbContext), receberá o que  foi passado em options.
        {

        }

        public DbSet<Heroi> Herois { get; set; }

        public DbSet<Batalha> Batalhas { get; set; }

        public DbSet<Arma> Armas { get; set; }

        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }

        public DbSet<IdentidadeSecreta> Identidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });//Falando para o banco de dados que aquela tabela é feita por uma chave composta.
            });
        }
    }
}
