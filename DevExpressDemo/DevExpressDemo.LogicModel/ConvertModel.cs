using DevExpressDemo.Data.Models;

namespace DevExpressDemo.LogicModel
{
    public static class ConvertModel
    {
        public static UserLogicModel ToLogicModel(this User user)
        {
            return user == null ? null : new UserLogicModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password
            };
        }

        public static User ToModel(this UserLogicModel user)
        {
            return user == null ? null : new User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password
            };
        }

        public static EmployeeLogicModel ToLogicModel(this Employee employee)
        {
            return employee == null ? null : new EmployeeLogicModel
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                DepId= employee.DepId,
                EmployeeSex =employee.EmployeeSex,
                EmployeeNo=employee.EmployeeNo,
                EmployeeAge=employee.EmployeeAge,
                BirthDate=employee.BirthDate,
                EmployeePhone = employee.EmployeePhone,
                EmployeeEmail=employee.EmployeeEmail,
                EmployeeAddress =employee.EmployeeAddress,
                EmployeeEducation = employee.EmployeeEducation,
                EmployeeOpus = employee.EmployeeOpus
            };
        }

        public static Employee ToModel(this EmployeeLogicModel employee)
        {
            return employee == null ? null : new Employee
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                DepId = employee.DepId,
                EmployeeSex = employee.EmployeeSex,
                EmployeeNo = employee.EmployeeNo,
                EmployeeAge = employee.EmployeeAge,
                BirthDate = employee.BirthDate,
                EmployeePhone = employee.EmployeePhone,
                EmployeeEmail = employee.EmployeeEmail,
                EmployeeAddress = employee.EmployeeAddress,
                EmployeeEducation = employee.EmployeeEducation,
                EmployeeOpus = employee.EmployeeOpus
            };
        }

        public static ShapeLogicModel ToLogicModel(this Shape shape)
        {
            return shape == null ? null : new ShapeLogicModel
            {
                ShapeId = shape.ShapeId,
                ShapeInfo = shape.ShapeInfo
            };
        }

        public static Shape ToModel(this ShapeLogicModel shape)
        {
            return shape == null ? null : new Shape
            {
                ShapeId = shape.ShapeId,
                ShapeInfo = shape.ShapeInfo
            };
        }

        public static DepartmentLogicModel ToLogicModel(this Department department)
        {
            return department == null ? null : new DepartmentLogicModel
            {
                DepId = department.DepId,
                DepNo = department.DepNo,
                DepName = department.DepName,
                OfficeLocation = department.OfficeLocation
            };
        }

        public static Department ToModel(this DepartmentLogicModel department)
        {
            return department == null ? null : new Department
            {
                DepId = department.DepId,
                DepNo = department.DepNo,
                DepName = department.DepName,
                OfficeLocation = department.OfficeLocation
            };
        }
    }
}
