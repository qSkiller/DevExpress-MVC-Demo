using System.Collections.Generic;
using System.Linq;
using DevExpressDemo.Data.Models;
using DevExpressDemo.ILogic;
using DevExpressDemo.IRepository;
using DevExpressDemo.LogicModel;
using DevExpressDemo.Repository.UnitOfWork;

namespace DevExpressDemo.Logic
{
    public class ShapeLogic : IShapeLogic
    { 
        private readonly IShapeRepository _shapeRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ShapeLogic(IShapeRepository shapeRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _shapeRepository = shapeRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(ShapeLogicModel model)
        {
            var shape = model.ToModel();
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _shapeRepository.Create(shape);
                unitOfwork.Commit();
            }
        }

        public void Edit(ShapeLogicModel model)
        {
            var shape = model.ToModel();
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _shapeRepository.Edit(shape);
                unitOfwork.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _shapeRepository.Delete(id);
                unitOfwork.Commit();
            }
        }

        public ShapeLogicModel Get(int id)
        {
            var shape = _shapeRepository.Get(id);
            return shape?.ToLogicModel();
        }

        public IEnumerable<ShapeLogicModel> GetAll()
        {
            return _shapeRepository.Query()?.Select(x => new ShapeLogicModel
            {
                ShapeId = x.ShapeId,
                ShapeInfo = x.ShapeInfo
            }).ToList();
        }

        public IEnumerable<Shape> Get(string shapeInfo)
        {
            return _shapeRepository.Query().Where(x => x.ShapeInfo.Contains(shapeInfo)).ToList();
        }
    }
}
