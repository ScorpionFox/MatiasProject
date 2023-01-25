using MatiasProject.Models.Domain;

namespace MatiasProject.Repositories.Abstract
{
    public interface IWydawnictwoService
    {
        bool Add(Wydawnictwo model);
        bool Update(Wydawnictwo model);
        bool Delete(int model);
        Wydawnictwo FindById(int id);
        IEnumerable<Wydawnictwo> GetAll();
    }
}
