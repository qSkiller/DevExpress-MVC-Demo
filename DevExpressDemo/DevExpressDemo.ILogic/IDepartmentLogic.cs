using System.Collections.Generic;
using DevExpressDemo.LogicModel;

namespace DevExpressDemo.ILogic
{
    public interface IDepartmentLogic
    {
        void Create(DepartmentLogicModel model);
        void Edit(DepartmentLogicModel model);
        void Delete(int id);
        DepartmentLogicModel Get(int id);
        IEnumerable<DepartmentLogicModel> GetAll();
    }
}

