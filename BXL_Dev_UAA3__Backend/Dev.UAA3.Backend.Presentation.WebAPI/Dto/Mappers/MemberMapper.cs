using Dev.UAA3.Backend.Domain.Models;
using Dev.UAA3.Backend.Presentation.WebAPI.Dto.Response;

namespace Dev.UAA3.Backend.Presentation.WebAPI.Dto.Mappers
{
    public static class MemberMapper
    {
        public static MemberResponseDto ToDto(this Member member)
        {
            return new MemberResponseDto()
            {
                Id = member.Id,
                Email = member.Email,
            };
        }
    }
}
