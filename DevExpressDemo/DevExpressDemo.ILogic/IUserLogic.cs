using System.Collections.Generic;
using DevExpressDemo.Data.Models;

namespace DevExpressDemo.ILogic
{
    public interface IUserLogic
    {
        string Create(User model);
        void Edit(User model);
        void Delete(int id);
        User Get(int id);
        string Login(string userName, string password);
        IEnumerable<User> QuesyByName(string userName);
    }
}
