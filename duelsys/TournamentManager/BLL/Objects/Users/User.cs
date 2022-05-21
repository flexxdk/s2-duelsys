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
        [EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; }

        [Required(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email address")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A password is required")]
        [DataType(DataType.Password)]
        [Browsable(false)]
        public string? Password { get; set; }

        [Browsable(false)]
        public string? Salt { get; set; }
    }
}
