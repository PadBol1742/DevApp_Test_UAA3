using Dev.UAA3.Backend.Domain.Models;
using Dev.UAA3.Backend.Presentation.WebAPI.Dto.Response;

namespace Dev.UAA3.Backend.Presentation.WebAPI.Dto.Mappers
{
    public static class ReservationMapper
    {
        public static ReservationResponseDto ToDto(this Reservation reservation)
        {
            return new ReservationResponseDto()
            {
                Id = reservation.Id,
                Name = reservation.Name,
                DateReserved = reservation.DateReserved,
                Member = reservation.Member.ToDto(),
                Room = reservation.Room.ToDto(),
            };
        }
    }
}
