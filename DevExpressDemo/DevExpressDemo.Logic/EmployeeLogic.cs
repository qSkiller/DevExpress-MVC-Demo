using System.Collections.Generic;
using System.Linq;
using DevExpressDemo.Data.Models;
using DevExpressDemo.ILogic;
using DevExpressDemo.IRepository;
using DevExpressDemo.LogicModel;
using DevExpressDemo.Repository.UnitOfWork;

namespace DevExpressDemo.Logic
{
    public class EmployeeLogic: IEmployeeLogic
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        
        public EmployeeLogic(IEmployeeRepository employeeRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _employeeRepository = employeeRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(EmployeeLogicModel model)
        {
            var employee = model.ToModel();
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _employeeRepository.Create(employee);
                unitOfwork.Commit();
            }
        }

        public void Edit(EmployeeLogicModel model)
        {
            var employee = model.ToModel();
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _employeeRepository.Edit(employee);
                unitOfwork.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _employeeRepository.Delete(id);
                unitOfwork.Commit();
            }
        }

        public EmployeeLogicModel Get(int id)
        {
            var employee = _employeeRepository.Get(id);
            return employee?.ToLogicModel();
        }

        public IEnumerable<EmployeeLogicModel> GetAll()
        {
            return _employeeRepository.Query()?.Select(x => new EmployeeLogicModel
            {
                EmployeeId = x.EmployeeId,
                EmployeeName = x.EmployeeName,
                DepId = x.DepId,
                EmployeeSex = x.EmployeeSex,
                EmployeeNo = x.EmployeeNo,
                EmployeeAge = x.EmployeeAge,
                BirthDate = x.BirthDate,
                EmployeePhone = x.EmployeePhone,
                EmployeeEmail = x.EmployeeEmail,
                EmployeeAddress = x.EmployeeAddress,
                EmployeeEducation = x.EmployeeEducation,
                EmployeeOpus = x.EmployeeOpus
            }).ToList();
        }

        public IEnumerable<Employee> Get(string name)
        {
            return _employeeRepository.Query().Where(x => x.EmployeeName.Contains(name)).ToList();
        }

        public bool CheckExist(string employeeName)
        {
            if (_employeeRepository.Query().Any())
            {
                return _employeeRepository
                    .Query().Any(x => x.EmployeeName.Equals(employeeName));
            }
            return false;
        }
    }
}
