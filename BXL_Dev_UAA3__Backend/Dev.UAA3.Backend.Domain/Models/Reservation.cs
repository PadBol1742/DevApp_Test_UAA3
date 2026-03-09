namespace Dev.UAA3.Backend.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime DateReserved { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; } = default!;
        public int RoomId { get; set; }
        public Room Room { get; set; } = default!;

        /// <summary>
        /// Constructeur privé pour EFCore
        /// </summary>
        private Reservation() { }

        /// <summary>
        /// Constructeur pour créer une reservation
        /// </summary>
        /// <param name="name">Nom de la reservation</param>
        /// <param name="dateReserved">Date de debut</param>
        /// <param name="endDate">Date de fin</param>
        /// <param name="member">Membre qui a effectuer la reservation</param>
        /// <param name="room">Salle reservé</param>
        public Reservation(string name, DateTime dateReserved, int memberId, int roomId)
        {
            Name = name;
            DateReserved = dateReserved;
            MemberId = memberId;
            RoomId = roomId;
        }

        /// <summary>
        /// Constructeur pour récuperer une reservation
        /// </summary>
        /// <param name="id">Identifiant de la reservation</param>
        /// <param name="name">Nom de la reservation</param>
        /// <param name="dateReserved">Date de debut</param>
        /// <param name="member">Membre qui a effectuer la reservation</param>
        /// <param name="room">Salle reservé</param>
        public Reservation(int id, string name, DateTime dateReserved, Member member, Room room)
        {
            Id = id;
            Name = name;
            DateReserved = dateReserved;
            Member = member;
            MemberId = member.Id;
            Room = room;
            RoomId = room.Id;
        }
    }
}
