using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Objects.Users
{
    public class Credentials
    {
        [Required(ErrorMessage = "Your email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address entered")]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Your password is required")]
        [StringLength(50)]
        public string? Password { get; set; }
    }
}
