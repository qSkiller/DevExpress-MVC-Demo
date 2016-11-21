using System.Collections.Generic;
using DevExpressDemo.LogicModel;

namespace DevExpressDemo.ILogic
{
    public interface IEmployeeLogic
    {
        void Create(EmployeeLogicModel model);
        void Edit(EmployeeLogicModel model);
        void Delete(int id);
        EmployeeLogicModel Get(int id);
        IEnumerable<EmployeeLogicModel> GetAll();
        bool CheckExist(string employeeName);
    }
}
