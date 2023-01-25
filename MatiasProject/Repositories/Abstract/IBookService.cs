using MatiasProject.Models.Domain;

namespace MatiasProject.Repositories.Abstract
{
    public interface IBookService
    {
        bool Add(Book model);
        bool Update(Book model);
        bool Delete(int model);
        Book FindById(int id);
        IEnumerable<Book> GetAll();
    }
}
