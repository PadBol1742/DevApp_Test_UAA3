using Dev.UAA3.Backend.Domain.Models;
using System.Linq.Expressions;

namespace Dev.UAA3.Backend.ApplicationCore.Interfaces
{
    public interface IReservationRepository
    {
        Reservation? GetById(int reservationId);
        IEnumerable<Reservation> GetByFilter(Expression<Func<Reservation, bool>> filter);
        bool CheckRoomOccupationAtDate(Reservation reservation);
        bool CheckReservationExists(Reservation reservation);
        Reservation Insert(Reservation reservation);
        bool Delete(int reservationId);
    }
}
