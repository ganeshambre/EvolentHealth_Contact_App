using EvolentHealth_Contact_App.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth_Contact_App.DAL
{
    public class UserDBContext : DbContext
    {
        public UserDBContext() : base(Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["EvolentContactDB"]))
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
