using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBooking.Interfaces
{
    public interface IAuthRepository<TEntity>
    {
        IEnumerable<TEntity> GetAllUsers();
        TEntity GetUser(long id);
        void CreateUser(TEntity entity);
        void UpdateUser(TEntity dbEntity, TEntity entity);
        void DeleteUser(TEntity entity);
        void AddToRole(long id);
    }
}
