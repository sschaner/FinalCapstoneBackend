using System.ComponentModel.DataAnnotations;

namespace FinalCapstoneBackend.DataTransferObjects.UserContext
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
