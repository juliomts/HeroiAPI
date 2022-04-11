namespace EFCore.Dominio
{
    public class Arma
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Heroi Heroi { get; set; }

        public string HeroiId { get; set; }
    }
}
//O dominio é o lugar onde serão colocadas as models.
//Solução -> Adicionar -> Novo projeto -> Biblioteca de classes.
