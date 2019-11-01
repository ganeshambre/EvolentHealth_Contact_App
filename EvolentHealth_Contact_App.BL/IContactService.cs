using EvolentHealth_Contact_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth_Contact_App.BL
{
    public interface IContactService
    {
        List<User> GetUsers();
        User GetUser(int id);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool InactivateUser(int id);

    }
}
