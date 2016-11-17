using System;

namespace DevExpressDemo.Repository.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
    }
}
