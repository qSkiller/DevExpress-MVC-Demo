using System.Data.Entity;

namespace DevExpressDemo.Data
{
    public interface IDbFactory
    {
        DbContext GetContext();
    }
}