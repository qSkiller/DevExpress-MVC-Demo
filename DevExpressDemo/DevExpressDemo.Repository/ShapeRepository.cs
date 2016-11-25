using System.Data.Entity;
using System.Linq;
using DevExpressDemo.Data;
using DevExpressDemo.Data.Models;
using DevExpressDemo.IRepository;

namespace DevExpressDemo.Repository
{
    public class ShapeRepository : RepositoryBase<Shape>, IShapeRepository
    {
        private readonly IDbFactory _dbFactory;
        private DbContext DataContext => _dbFactory.GetContext();
        private DbSet<Shape> Dbset => DataContext.Set<Shape>();

        public ShapeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public Shape Get(string shapeInfo)
        {
            return Dbset.FirstOrDefault(e => e.ShapeInfo == shapeInfo);
        }
    }
}
