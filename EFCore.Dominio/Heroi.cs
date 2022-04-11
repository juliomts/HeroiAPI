using System.Collections.Generic;

namespace EFCore.Dominio
{
    public class Heroi
    {
        public int Id{ get; set; }

        public string Nome { get; set; }

        public IdentidadeSecreta Identidade { get; set; }//Não é preciso por o "Id", o EF já reconhece que há uma relação entre as duas tabelas. E que nem sempre um herói precisa ter uma identidade secreta.

        public List<Arma> Armas { get; set; }//Um herói pode ter diversas armas

        public List<HeroiBatalha> HeroisBatalhas { get; set; }
    }
}
//public Batalha Batalha { get; set; }Seria usado, caso 1 heroi estivesse para uma batalha;

//public int BatalhaId { get; set; }
