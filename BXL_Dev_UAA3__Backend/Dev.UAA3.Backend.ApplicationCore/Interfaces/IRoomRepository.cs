using Dev.UAA3.Backend.Domain.Models;

namespace Dev.UAA3.Backend.ApplicationCore.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
    }
}
