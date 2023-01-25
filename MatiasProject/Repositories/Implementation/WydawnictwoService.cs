using MatiasProject.Models.Domain;
using MatiasProject.Repositories.Abstract;

namespace MatiasProject.Repositories.Implementation
{
    public class WydawnictwoService : IWydawnictwoService
    {
        private readonly DatabaseContext context;

        public WydawnictwoService(DatabaseContext context)
        {
            this.context = context;
        }

        public bool Add(Wydawnictwo model)
        {
            try
            {
                context.Wydawnictwo.Add(model);
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
                    context.Wydawnictwo.Remove(data);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Wydawnictwo FindById(int id)
        {
            return context.Wydawnictwo.Find(id);
        }

        public IEnumerable<Wydawnictwo> GetAll()
        {
            return context.Wydawnictwo.ToList();
        }

        public bool Update(Wydawnictwo model)
        {
            try
            {
                context.Wydawnictwo.Update(model);
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
