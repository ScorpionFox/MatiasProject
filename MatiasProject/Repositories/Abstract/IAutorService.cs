using MatiasProject.Models.Domain;

namespace MatiasProject.Repositories.Abstract
{
    public interface IAutorService
    {
        bool Add(Autor model);
        bool Update(Autor model);
        bool Delete(int model);
        Autor FindById(int id);
        IEnumerable<Autor> GetAll();
    }
}
