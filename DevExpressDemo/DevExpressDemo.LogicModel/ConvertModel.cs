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
                EmployeePhone = employee.EmployeePhone,
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
                EmployeePhone = employee.EmployeePhone,
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
    }
}
