using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth_Contact_App.Entities
{
    //public class User
    //{
    //    public int UserId { get; set; }
    //    public string FirstName { get; set; }

    //    public string LastName { get; set; }

    //    public string PhoneNumber { get; set; }

    //    public string Email { get; set; }

    //    public bool Status { get; set; }
    //}

    public class User
    {

        public int UserId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Please enter not more than 100 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Please enter not more than 100 characters")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("([(+]*[0-9]+[()+. -]*)", ErrorMessage = "Phone number has invalid characters")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression("[^@]+@[^\\.]+\\..+", ErrorMessage = "Email is not in correct format")]
        public string Email { get; set; }

        public bool Status { get; set; }
    }
}
