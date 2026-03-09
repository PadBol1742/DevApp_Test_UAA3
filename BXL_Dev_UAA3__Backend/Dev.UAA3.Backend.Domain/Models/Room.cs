namespace Dev.UAA3.Backend.Domain.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        /// <summary>
        /// Constructeur privé pour EFCore
        /// </summary>
        private Room() { }

        /// <summary>
        /// Constructeur pour créer une salle
        /// </summary>
        /// <param name="name">Nom de la salle</param>
        public Room(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Constructeur pour récuperer une salle
        /// </summary>
        /// <param name="id">Identifiant de la salle</param>
        /// <param name="name">Nom de la salle</param>
        public Room(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
