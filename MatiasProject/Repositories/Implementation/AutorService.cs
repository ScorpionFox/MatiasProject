using MatiasProject.Models.Domain;
using MatiasProject.Repositories.Abstract;

namespace MatiasProject.Repositories.Implementation
{
    public class AutorService : IAutorService
    {
        private readonly DatabaseContext context;

        public AutorService(DatabaseContext context)
        {
            this.context = context;
        }

        public bool Add(Autor model)
        {
            try
            {
                context.Autor.Add(model);
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
                    context.Autor.Remove(data);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Autor FindById(int id)
        {
            return context.Autor.Find(id);
        }

        public IEnumerable<Autor> GetAll()
        {
            return context.Autor.ToList();
        }

        public bool Update(Autor model)
        {
            try
            {
                context.Autor.Update(model);
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

