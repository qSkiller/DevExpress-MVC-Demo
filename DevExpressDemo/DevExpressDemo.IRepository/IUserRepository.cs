using DevExpressDemo.Data.Models;

namespace DevExpressDemo.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string userName);
    }
}
