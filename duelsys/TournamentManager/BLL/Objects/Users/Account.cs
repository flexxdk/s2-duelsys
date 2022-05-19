using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Objects.Users
{
    public abstract class Account
    {
        [Required]
        [Key]
        [Browsable(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "You must enter a first name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a last name")]
        public string? LastName { get; set; }
    }
}
