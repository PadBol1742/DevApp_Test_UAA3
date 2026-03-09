using Dev.UAA3.Backend.Domain.Models;
using Dev.UAA3.Backend.Presentation.WebAPI.Dto.Response;

namespace Dev.UAA3.Backend.Presentation.WebAPI.Dto.Mappers
{
    public static class RoomMapper
    {
        public static RoomResponseDto ToDto(this Room room)
        {
            return new RoomResponseDto()
            {
                Id = room.Id,
                Name = room.Name,
            };
        }
    }
}
