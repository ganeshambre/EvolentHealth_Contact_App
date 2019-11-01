using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolentHealth_Contact_App.Entities;
using EvolentHealth_Contact_App.DAL;

namespace EvolentHealth_Contact_App.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool AddUser(User user)
        {
            using (var context = new UserDBContext())
            {
                user.Status = true;
                context.Users.Add(user);
                context.SaveChanges();
            }

            return true;
        }

        public User GetUser(int id)
        {
            User user = null;
            using (var context = new UserDBContext())
            {
                user = context.Users.Where(u => u.UserId == id).FirstOrDefault();
            }
            return user;
        }

        public List<User> GetUsers()
        {
            List<User> users = null;
            using (var context = new UserDBContext())
            {
                users=context.Users.ToList<User>();
            }
            return users;
        }

        public bool UpdateUser(User user)
        {
            bool isSuccessful = false;
            using (var context = new UserDBContext())
            {
                var userToUpdate = context.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
                if (userToUpdate != null)
                {
                    userToUpdate.FirstName = user.FirstName;
                    userToUpdate.LastName = user.LastName;
                    userToUpdate.PhoneNumber = user.PhoneNumber;
                    userToUpdate.Email = user.Email;
                    userToUpdate.Status = userToUpdate.Status;
                    context.SaveChanges();
                    isSuccessful = true;
                }
                
            }
            return isSuccessful;
        }
    }
}
