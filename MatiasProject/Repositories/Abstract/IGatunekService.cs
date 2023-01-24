using MatiasProject.Models.Domain;

namespace MatiasProject.Repositories.Abstract
{
    public interface IGatunekService
    {
        bool Add(Gatunek model);
        bool Update(Gatunek model);
        bool Delete(int model);
        Gatunek FindById(int id);
        IEnumerable<Gatunek> GetAll();

    }
}
