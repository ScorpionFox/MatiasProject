using MatiasProject.Models.Domain;
using MatiasProject.Repositories.Abstract;

namespace MatiasProject.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext context;

        public BookService(DatabaseContext context)
        {
            this.context = context;
        }

        public bool Add(Book model)
        {
            try
            {
                context.Book.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                {
                    return false;
                }
                else
                {
                    context.Book.Remove(data);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book FindById(int id)
        {
            return context.Book.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {

            var data = (from book in context.Book
                        join autor in context.Autor
                        on book.AutorId equals autor.Id
                        join wydawnictwo in context.Wydawnictwo
                        on book.WydawnictwoId equals wydawnictwo.Id
                        join gatunek in context.Gatunek on book.GatunekId equals gatunek.Id
                        select new Book
                        {
                            Id = book.Id,
                            AutorId = book.AutorId,
                            WydawnictwoId = book.WydawnictwoId,
                            GatunekId = book.GatunekId,
                            Isbn = book.Isbn,
                            Title = book.Title,
                            TotalPages = book.TotalPages,
                            GatunekName = gatunek.Name,
                            NameAutor = autor.NameAutor,
                            NameWydawnictwo = wydawnictwo.NameWydawnictwo
                        }
                        ).ToList();
            return data;
        }

        public bool Update(Book model)
        {
            try
            {
                context.Book.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
