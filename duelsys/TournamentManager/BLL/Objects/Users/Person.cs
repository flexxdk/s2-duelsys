using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Objects.Users
{
    public abstract class Person
    {
        [Key]
        [Required]
        [Browsable(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "You must enter a first name")]
        public string? Name { get; set; }

        public string? SurName { get; set; }
    }
}
