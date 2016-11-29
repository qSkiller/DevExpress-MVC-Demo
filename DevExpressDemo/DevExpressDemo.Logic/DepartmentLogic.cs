using DevExpressDemo.ILogic;
using DevExpressDemo.IRepository;
using DevExpressDemo.LogicModel;
using DevExpressDemo.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace DevExpressDemo.Logic
{
    public class DepartmentLogic: IDepartmentLogic
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public DepartmentLogic(IDepartmentRepository departmentRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _departmentRepository = departmentRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(DepartmentLogicModel model)
        {
            var department = model.ToModel();
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _departmentRepository.Create(department);
                unitOfwork.Commit();
            }
        }

        public void Edit(DepartmentLogicModel model)
        {
            var employee = model.ToModel();
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _departmentRepository.Edit(employee);
                unitOfwork.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _departmentRepository.Delete(id);
                unitOfwork.Commit();
            }
        }

        public DepartmentLogicModel Get(int id)
        {
            var department = _departmentRepository.Get(id);
            return department?.ToLogicModel();
        }

        public IEnumerable<DepartmentLogicModel> GetAll()
        {
            return _departmentRepository.Query()?.Select(x => new DepartmentLogicModel
            {
                DepId = x.DepId,
                DepNo = x.DepNo,
                DepName = x.DepName,
                OfficeLocation = x.OfficeLocation
            }).ToList();
        }
    }
}
