using System.ComponentModel.DataAnnotations;

namespace EvolentHealth_Contact_App.Entities
{
    /// <summary>
    /// User Entity
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User first name
        /// </summary>
        [Required]
        [MaxLength(100, ErrorMessage = "Please enter not more than 100 characters")]
        public string FirstName { get; set; }
        // <summary>
        /// User last name
        /// </summary>
        [Required]
        [MaxLength(100, ErrorMessage = "Please enter not more than 100 characters")]
        public string LastName { get; set; }
        // <summary>
        /// User phone number
        /// </summary>
        [Required]
        [RegularExpression("([(+]*[0-9]+[()+. -]*)", ErrorMessage = "Phone number has invalid characters")]
        public string PhoneNumber { get; set; }
        // <summary>
        /// User email address
        /// </summary>
        [Required]
        [RegularExpression("[^@]+@[^\\.]+\\..+", ErrorMessage = "Email is not in correct format")]
        public string Email { get; set; }
        // <summary>
        /// Is user active or inactive
        /// </summary>
        public bool Status { get; set; }
    }
}
