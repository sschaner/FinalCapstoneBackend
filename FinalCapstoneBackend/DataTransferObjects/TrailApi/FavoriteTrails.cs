using FinalCapstoneBackend.DataTransferObjects.UserContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCapstoneBackend.DataTransferObjects.TrailApi
{
    public class FavoriteTrails
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int TrailId { get; set; }
        [ForeignKey("Trail")]
        public Trail Trail { get; set; }
    }
}
