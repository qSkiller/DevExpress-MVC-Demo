using System.Data.Entity;
using System.Linq;
using DevExpressDemo.Data;
using DevExpressDemo.Data.Models;
using DevExpressDemo.IRepository;

namespace DevExpressDemo.Repository
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        private readonly IDbFactory _dbFactory;
        private DbContext DataContext => _dbFactory.GetContext();
        private DbSet<Department> Dbset => DataContext.Set<Department>();

        public DepartmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public Department Get(string depName)
        {
            return Dbset.FirstOrDefault(e => e.DepName == depName);

        }
    }
}
