using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using DTO.Users;
using BLL.Enums;

namespace BLL.Objects.Users
{
    public class User : Account
    {
        [Required(ErrorMessage = "No role selected")]
        [Display(Name = "Role")]
        public UserRole Role { get; set; }

        [Required(ErrorMessage = "Invalid email address")]
        [EmailAddress]
        [Display(Name = "Email address")]
        public String? Email { get; set; }

        [Required(ErrorMessage = "A password is required")]
        [DataType(DataType.Password)]
        [Browsable(false)]
        public string? Password { get; set; }

        [Browsable(false)]
        public string? Salt { get; set; }
    }
}
