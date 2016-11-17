using System.Collections.Generic;
using System.Linq;
using DevExpressDemo.Data.Models;
using DevExpressDemo.ILogic;
using DevExpressDemo.IRepository;
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

        public void Create(Employee model)
        {
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _employeeRepository.Create(model);
                unitOfwork.Commit();
            }
        }

        public void Edit(Employee model)
        {
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _employeeRepository.Edit(model);
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

        public Employee Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.Query().ToList();
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
