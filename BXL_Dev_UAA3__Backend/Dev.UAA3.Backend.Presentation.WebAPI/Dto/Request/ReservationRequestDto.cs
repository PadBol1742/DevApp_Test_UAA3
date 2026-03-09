using System.ComponentModel.DataAnnotations;

namespace Dev.UAA3.Backend.Presentation.WebAPI.Dto.Request
{
    public class ReservationRequestDto
    {
        [Required]
        [MinLength(5), MaxLength(150)]
        public required string Name { get; set; }

        [Required]
        public required DateTime DateReserved { get; set; }
        
        [Required]        
        public required int RoomId { get; set; }
    }
}
