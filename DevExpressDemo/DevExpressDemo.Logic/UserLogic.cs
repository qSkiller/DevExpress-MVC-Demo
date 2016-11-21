using System.Collections.Generic;
using System.Linq;
using DevExpressDemo.ILogic;
using DevExpressDemo.IRepository;
using DevExpressDemo.LogicModel;
using DevExpressDemo.Repository.UnitOfWork;

namespace DevExpressDemo.Logic
{
    public class UserLogic: IUserLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UserLogic(IUserRepository userRepository,IUnitOfWorkFactory unitOfWorkFactory)
        {
            _userRepository = userRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public string Create(UserLogicModel model)
        {
            var user = model.ToModel();
            var message = "";
            if (!CheckIfExist(user.UserName))
            {
                using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
                {
                    _userRepository.Create(user);
                    unitOfwork.Commit();
                }
            }
            else
            {
                message = "the username was registered, please select a new username to register.";
            }
            return message;
        }

        public void Edit(UserLogicModel model)
        {
            var user = model.ToModel();
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _userRepository.Edit(user);
                unitOfwork.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _userRepository.Delete(id);
                unitOfwork.Commit();
            }
        }

        public string Login(string userName, string password)
        {
            var user = _userRepository.Get(userName);

            if (user == null)
            {
                return "the username is not register";
            }

            return user.Password.Equals(password) ? user.UserId.ToString() : "the password error";
        }

        public IEnumerable<UserLogicModel> GetAll()
        {
            return _userRepository.Query()?.Select(x => new UserLogicModel
            {
                UserId = x.UserId,
                UserName=x.UserName,
                Password = x.Password
            }).ToList();
        }

        public UserLogicModel Get(int id)
        {
            var user = _userRepository.Get(id);
            return user?.ToLogicModel();
        }

        private bool CheckIfExist(string userName)
        {
            try
            {
                return _userRepository.Query().Where(x => x.UserName == userName).ToList().Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
