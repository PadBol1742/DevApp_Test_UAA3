namespace Dev.UAA3.Backend.Presentation.WebAPI.Dto.Response
{
    public class ReservationResponseDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime DateReserved { get; set; }
        public required MemberResponseDto Member { get; set; }
        public required RoomResponseDto Room { get; set; }
    }

    public class ReservationItemResponseDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime DateReserved { get; set; }
        public required MemberResponseDto Member { get; set; }
        public required RoomResponseDto Room { get; set; }
    }
}
