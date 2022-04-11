using EFCore.Dominio;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IFCoreRepository
    {
        void Add<T> (T entity) where T : class;//é uma assinatura generica aceitado qualquer váriavel, com um tipo qualquer, como paramentro.

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<Heroi[]> GetAllHerois(bool incluirBatalha = false);

        Task<Heroi> GetHeroiById(int id, bool incluirBatalha = false);

        Task<Heroi[]> GetHeroisByNome(string nome, bool incluirBatalha = false);

        Task<Batalha[]> GetAllBatalhas(bool incluirHerois = false);

        Task<Batalha> GetBatalhaById(int id, bool incluirHerois = false);
    }
}
