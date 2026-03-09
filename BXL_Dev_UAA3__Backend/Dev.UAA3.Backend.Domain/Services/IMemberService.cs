using Dev.UAA3.Backend.Domain.Models;

namespace Dev.UAA3.Backend.Domain.Services
{
    //! Pourquoi dans le domain au lieu du dossier "Interfaces" de l'App Core ?
    public interface IMemberService
    {
        public Member Register(string email, string password);
        public Member Login(string email, string password);
    }
}
