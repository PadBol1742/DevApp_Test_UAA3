using Dev.UAA3.Backend.Domain.Services;
using Dev.UAA3.Backend.Presentation.WebAPI.Dto.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dev.UAA3.Backend.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RoomController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public RoomController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rooms = _reservationService.GetReservableRooms().Select(RoomMapper.ToDto);
            return Ok(rooms);
        }

        [HttpGet("{id}/Reservation")]
        public IActionResult GetReservations([FromRoute] int id)
        {
            var reservations = _reservationService.GetRoomReservations(id).Select(ReservationMapper.ToDto);
            return Ok(reservations);
        }
    }
}
