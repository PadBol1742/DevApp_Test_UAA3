using Dev.UAA3.Backend.Domain.Models;

//! Pourquoi dans le domain au lieu du dossier "Interfaces" de l'App Core ?

namespace Dev.UAA3.Backend.Domain.Services
{
    public interface IReservationService
    {
        Reservation Create(Reservation reservation);
        bool Cancel(int reservationId, int memberId);

        IEnumerable<Reservation> GetMemberReservations(int memberId);
        IEnumerable<Reservation> GetRoomReservations(int roomId);

        IEnumerable<Room> GetReservableRooms();
    }
}
