using Dev.UAA3.Backend.ApplicationCore.Interfaces;
using Dev.UAA3.Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dev.UAA3.Backend.Infrastructure.Database.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _dbContext;
        public RoomRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IEnumerable<Room> GetAll()
        {
            return _dbContext.Rooms.AsNoTracking().ToList();
        }
    }
}
