namespace Dev.UAA3.Backend.Domain.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string? Password { get; set; }

        /// <summary>
        /// Constructeur privé pour EFCore
        /// </summary>
        private Member() { }

        /// <summary>
        /// Constructeur pour créer un nouveau membre
        /// </summary>
        /// <param name="email">Email du membre</param>
        /// <param name="passwordHashed">Mot de passe hashé</param>
        public Member(string email, string passwordHashed)
        {
            Email = email;
            Password = passwordHashed;
        }

        /// <summary>
        /// Constructeur pour récuperer un membre depuis la DB
        /// </summary>
        /// <param name="id">Identifiant du membre</param>
        /// <param name="email">Email du membre</param>
        public Member(int id, string email)
        {
            Id = id;
            Email = email;
            Password = null;
        }
    }
}
