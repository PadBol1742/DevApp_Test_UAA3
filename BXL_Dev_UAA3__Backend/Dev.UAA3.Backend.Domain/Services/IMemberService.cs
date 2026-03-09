using Dev.UAA3.Backend.Domain.Models;

namespace Dev.UAA3.Backend.Domain.Services
{
    public interface IMemberService
    {
        public Member Register(string email, string password);
        public Member Login(string email, string password);
    }
}
