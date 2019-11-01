using EvolentHealth_Contact_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth_Contact_App.Repository
{
    public interface IUserRepository
    {
        bool AddUser(User user);

        bool UpdateUser(User user);

        User GetUser(int id);

        List<User> GetUsers();
    }
}
