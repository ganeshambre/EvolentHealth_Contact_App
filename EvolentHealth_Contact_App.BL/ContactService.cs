using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolentHealth_Contact_App.Entities;
using EvolentHealth_Contact_App.Repository;

namespace EvolentHealth_Contact_App.BL
{
    public class ContactService : IContactService
    {
        private readonly IUserRepository _userRepository;
        public ContactService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public bool InactivateUser(int id)
        {
            var user = _userRepository.GetUser(id);
            var isSuccess = false;
            if (user!=null && user.Status)
            {
                user.Status = true;
                isSuccess =_userRepository.UpdateUser(user);
            }
            return isSuccess;
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}
