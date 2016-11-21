using DevExpressDemo.LogicModel;

namespace DevExpressDemo.Models
{
    public static class ConvertModel
    {
        public static UserLogicModel ToLogicModel(this UserModel user)
        {
            return user == null ? null : new UserLogicModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password
            };
        }

        public static UserModel ToViewModel(this UserLogicModel user)
        {
            return user == null ? null : new UserModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password
            };
        }

        public static EmployeeLogicModel ToLogicModel(this EmployeeModel employee)
        {
            return employee == null ? null : new EmployeeLogicModel
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                EmployeePhone = employee.EmployeePhone,
                EmployeeAddress = employee.EmployeeAddress,
                EmployeeEducation = employee.EmployeeEducation,
                EmployeeOpus = employee.EmployeeOpus
            };
        }

        public static EmployeeModel ToViewModel(this EmployeeLogicModel employee)
        {
            return employee == null ? null : new EmployeeModel
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                EmployeePhone = employee.EmployeePhone,
                EmployeeAddress = employee.EmployeeAddress,
                EmployeeEducation = employee.EmployeeEducation,
                EmployeeOpus = employee.EmployeeOpus
            };
        }
    }
}