using Dev.UAA3.Backend.Domain.Models;
using Dev.UAA3.Backend.Domain.Services;
using Dev.UAA3.Backend.Presentation.WebAPI.Dto.Mappers;
using Dev.UAA3.Backend.Presentation.WebAPI.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dev.UAA3.Backend.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ReservationRequestDto requestDto)
        {
            int memberId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            Reservation reservation = new Reservation(
                name: requestDto.Name,
                dateReserved: requestDto.DateReserved,
                memberId: memberId,
                roomId: requestDto.RoomId
            );

            var reservationCreated = _reservationService.Create(reservation).ToDto();
            return CreatedAtAction(null, reservationCreated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            int memberId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            bool success = _reservationService.Cancel(id, memberId);

            if(!success)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        public IActionResult GetMemberReservation()
        {
            int memberId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var reservations = _reservationService.GetMemberReservations(memberId).Select(ReservationMapper.ToDto);

            return Ok(reservations);
        }
    }
}
