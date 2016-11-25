using System.Collections.Generic;
using DevExpressDemo.LogicModel;

namespace DevExpressDemo.ILogic
{
    public interface IShapeLogic
    {
        void Create(ShapeLogicModel model);
        void Edit(ShapeLogicModel model);
        void Delete(int id);
        ShapeLogicModel Get(int id);
        IEnumerable<ShapeLogicModel> GetAll();
    }
}

