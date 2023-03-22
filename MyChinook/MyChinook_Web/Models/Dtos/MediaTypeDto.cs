using System.ComponentModel.DataAnnotations;

namespace MyChinook_Web.Models.Dtos
{
    public class MediaTypeDto
    {      
        public int MediaTypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
