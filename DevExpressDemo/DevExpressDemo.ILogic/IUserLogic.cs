﻿using System.Collections.Generic;
using DevExpressDemo.LogicModel;

namespace DevExpressDemo.ILogic
{
    public interface IUserLogic
    {
        string Create(UserLogicModel model);
        void Edit(UserLogicModel model);
        void Delete(int id);
        UserLogicModel Get(int id);
        string Login(string userName, string password);
    }
}
