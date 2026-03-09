using Dev.UAA3.Backend.ApplicationCore.Interfaces;
using Dev.UAA3.Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.Common;
using System.Linq.Expressions;

namespace Dev.UAA3.Backend.Infrastructure.Database.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _dbContext;
        public ReservationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Reservation? GetById(int reservationId)
        {
            return _dbContext.Reservations
                        .Include(r => r.Member)
                        .Include(r => r.Room)
                        .AsNoTracking()
                        .SingleOrDefault(r => r.Id == reservationId);
        }

        public IEnumerable<Reservation> GetByFilter(Expression<Func<Reservation, bool>> filter)
        {
            return _dbContext.Reservations
                        .Include(r => r.Member)
                        .Include(r => r.Room)
                        .AsNoTracking()
                        .Where(filter)
                        .ToList();
        }

        public bool CheckRoomOccupationAtDate(Reservation reservation)
        {
            return _dbContext.Reservations.Any(r => r.DateReserved == reservation.DateReserved
                    && r.RoomId == reservation.RoomId);
        }

        public bool CheckReservationExists(Reservation reservation)
        {
            return _dbContext.Reservations.Any(r => r.Name == reservation.Name
                    && r.DateReserved == reservation.DateReserved
                    && r.MemberId == reservation.MemberId
                    && r.RoomId == reservation.RoomId
            );
        }

        public Reservation Insert(Reservation reservation)
        {
            EntityEntry<Reservation> element = _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();

            return GetById(element.Entity.Id) ?? throw new DbUpdateException(); //? Pq pas juste element.Entity ?
        }

        public bool Delete(int reservationId)
        {
            Reservation? target = GetById(reservationId);

            if (target is null)
                return false;

            _dbContext.Remove(target);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
