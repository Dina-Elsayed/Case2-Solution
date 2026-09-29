using Case2_Solution.Data;
using Case2_Solution.Repos.Interface;

namespace Case2_Solution.Repos.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {

        private readonly AppDbContext _context;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
        }
    }
}
