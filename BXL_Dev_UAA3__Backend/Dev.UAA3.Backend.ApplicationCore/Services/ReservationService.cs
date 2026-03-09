using Dev.UAA3.Backend.ApplicationCore.Interfaces;
using Dev.UAA3.Backend.Domain.BusinessExceptions;
using Dev.UAA3.Backend.Domain.Models;
using Dev.UAA3.Backend.Domain.Services;

namespace Dev.UAA3.Backend.ApplicationCore.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        public ReservationService(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }
                
        public Reservation Create(Reservation reservation)
        {
            if (_reservationRepository.CheckReservationExists(reservation))
                throw new ReservationAlreadyExistsException();

            // On Vérifie si la salle demandée est déjà occupée à la date demandée.
            if (_reservationRepository.CheckRoomOccupationAtDate(reservation))
                throw new ReservationRoomNotAvalaibleException();

            return _reservationRepository.Insert(reservation);
        }

        public bool Cancel(int reservationId, int memberId)
        {
            Reservation? target = _reservationRepository.GetById(reservationId);

            if (target is null)
                throw new ReservationNotFoundException();

            if(target.MemberId != memberId)
                throw new ReservationInvalidException();

            return _reservationRepository.Delete(reservationId);
        }

        public IEnumerable<Reservation> GetMemberReservations(int memberId)
        {
            return _reservationRepository.GetByFilter(r => r.Member.Id == memberId);
        }

        public IEnumerable<Reservation> GetRoomReservations(int roomId)
        {
            return _reservationRepository.GetByFilter(r => r.Room.Id == roomId);
        }

        public IEnumerable<Room> GetReservableRooms()
        {
            return _roomRepository.GetAll();
        }
    }
}
