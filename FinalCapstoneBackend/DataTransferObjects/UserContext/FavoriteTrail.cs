using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalCapstoneBackend.DataTransferObjects.UserContext
{
    public class FavoriteTrail
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }
       // [ForeignKey("UserId")]
        //public User user { get; set; }
        
        
        [Required]
        public string TrailId { get; set; }
    }
}
