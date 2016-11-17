using System.Data.Entity;
using System.Linq;
using DevExpressDemo.Data;
using DevExpressDemo.Data.Models;
using DevExpressDemo.IRepository;

namespace DevExpressDemo.Repository
{
    public class EmployeeRepository: RepositoryBase<Employee>,IEmployeeRepository
    {
        private readonly IDbFactory _dbFactory;
        private DbContext DataContext => _dbFactory.GetContext();
        private DbSet<Employee> Dbset => DataContext.Set<Employee>();

        public EmployeeRepository(IDbFactory dbFactory):base(dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public Employee Get(string employeeName)
        {
            return Dbset.FirstOrDefault(e => e.EmployeeName==employeeName);
        }
    }
}
