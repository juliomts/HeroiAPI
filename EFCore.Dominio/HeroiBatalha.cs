namespace EFCore.Dominio
{
    public class HeroiBatalha//Relacionamento muitos para muitos.
                             //Um herói pode estar em muitas batalhas
                             //Assim como uma batalha pode ter vários hérois.
                             //Tabela HeroiBatalha, tabela de interserção que junta as duas tabelas 
    {
        public int HeroiId { get; set; }

        public Heroi Heroi { get; set; } //Tabela Herói.
        
        public int BatalhaId { get; set; }

        public Batalha Batalha { get; set; } //Tabela Batalha.
    }
}
