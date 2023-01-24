using MatiasProject.Models.Domain;
using MatiasProject.Repositories.Abstract;

namespace MatiasProject.Repositories.Implementation
{
    public class GatunekService : IGatunekService
    {
        private readonly DatabaseContext context;

        public GatunekService(DatabaseContext context)
        {
            this.context = context;
        }

        public bool Add(Gatunek model)
        {
            try
            {
                context.Gatunek.Add(model);
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
                    context.Gatunek.Remove(data);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Gatunek FindById(int id)
        {
            return context.Gatunek.Find(id);
        }

        public IEnumerable<Gatunek> GetAll()
        {
            return context.Gatunek.ToList();
        }

        public bool Update(Gatunek model)
        {
            try
            {
                context.Gatunek.Update(model);
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
