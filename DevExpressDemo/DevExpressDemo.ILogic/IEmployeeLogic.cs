using System.Collections.Generic;
using DevExpressDemo.Data.Models;

namespace DevExpressDemo.ILogic
{
    public interface IEmployeeLogic
    {
        void Create(Employee model);
        void Edit(Employee model);
        void Delete(int id);
        Employee Get(int id);
        IEnumerable<Employee> GetAll();
        bool CheckExist(string employeeName);
    }
}
