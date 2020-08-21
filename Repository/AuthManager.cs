using GoBooking.Interfaces;
using GoBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoBooking.Repository
{
    public class AuthManager : IAuthRepository<AppUser>
    {
        readonly AuthDbContext _authDbContext;

        public AuthManager(AuthDbContext context)
        {
            _authDbContext = context;
        }

        public void AddToRole(long id)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(AppUser entity)
        {
            _authDbContext.AppUser.Add(entity);
            _authDbContext.SaveChanges();
        }

        public void DeleteUser(AppUser entity)
        {
            _authDbContext.AppUser.Remove(entity);
            _authDbContext.SaveChanges();
        }

        public IEnumerable<AppUser> GetAllUsers()
        {
            return _authDbContext.AppUser.ToList();
        }

        public AppUser GetUser(long id)
        {
            return _authDbContext.AppUser
                .FirstOrDefault(x => x.UserID == id);
        }

        public void UpdateUser(AppUser dbUser, AppUser user)
        {
            dbUser.UserID = user.UserID;
            dbUser.UserName = user.UserName;
            dbUser.PasswordHash = user.PasswordHash;
            dbUser.Roles = user.Roles;
            dbUser.Email = user.Email;
            dbUser.Claims = user.Claims;

            _authDbContext.SaveChanges();
        }
    }
}
