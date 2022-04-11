using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCapstoneBackend.DataTransferObjects.UserContext
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Your first name must be 100 characters or less.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Your last name must be 100 characters or less.")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
       // public object FavoriteTrails { get; internal set; }
    }
}
