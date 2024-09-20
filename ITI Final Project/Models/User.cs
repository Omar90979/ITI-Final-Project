using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITI_Final_Project.Models
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(7, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 7 char")]
        [Required(ErrorMessage = "The User First Name is required.")]
        [DisplayName("User First Name")]
        public string? FirstName { get; set; }
        [StringLength(7, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 7 char")]
        [Required(ErrorMessage = "The User Last Name is required.")]
        [DisplayName("User Last Name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "The User Email is required.")]
        [EmailAddress]
        [DisplayName("User Email")]
        public string? Email { get; set; }
        [Required]
        [MinLength(4)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


    }
}
