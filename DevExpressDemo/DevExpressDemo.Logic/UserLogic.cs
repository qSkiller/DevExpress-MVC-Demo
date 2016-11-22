using System;
using System.Collections.Generic;
using System.Linq;
using DevExpressDemo.ILogic;
using DevExpressDemo.IRepository;
using DevExpressDemo.Logic.Tools;
using DevExpressDemo.LogicModel;
using DevExpressDemo.Repository.UnitOfWork;

namespace DevExpressDemo.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UserLogic(IUserRepository userRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _userRepository = userRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public string Create(UserLogicModel model)
        {
            var user = model.ToModel();
            user.Password = TokenGenerator.EncodeToken(model.Password);
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
                message = "The username was registered, please select a new username to register.";
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

        public string Login(UserLogicModel model)
        {
            var user = model.ToModel();
            var encodePassword = TokenGenerator.EncodeToken(user.Password);
            var isLoginSuccess = _userRepository.Query().FirstOrDefault(x => x.UserName == user.UserName && x.Password == encodePassword) != null;

            return isLoginSuccess
                ? TokenGenerator.Generate(user.UserName, user.Password, DateTime.MaxValue.ToString("yyyy-MM-dd hh:mm")) : string.Empty;
        }

        public IEnumerable<UserLogicModel> GetAll()
        {
            return _userRepository.Query()?.Select(x => new UserLogicModel
            {
                UserId = x.UserId,
                UserName = x.UserName,
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
