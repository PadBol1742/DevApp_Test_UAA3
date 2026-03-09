using Dev.UAA3.Backend.Domain.Models;

namespace Dev.UAA3.Backend.ApplicationCore.Interfaces
{
    public interface IMemberRepository
    {
        Member Create(Member member);
        Member? GetByEmail(string email);
        string GetPasswordHashed(string email);
    }
}
