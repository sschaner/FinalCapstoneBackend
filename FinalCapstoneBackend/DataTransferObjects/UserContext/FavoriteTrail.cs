using System.ComponentModel.DataAnnotations;

namespace FinalCapstoneBackend.DataTransferObjects.UserContext
{
    public class FavoriteTrail
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }        
        
        [Required]
        public string TrailId { get; set; }
    }
}
