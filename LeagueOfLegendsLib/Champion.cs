namespace LeagueOfLegendsLib
{
    public class Champion
    {
        private string _name;
        private string _role;
        private string _decription;
        private string _difficulty;
        public int Id { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value),"Name cannot be null or empty.");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name must be at least 2 characters long.", nameof(value));
                }
                _name = value;
            }
        }
        public string Role
        {
            get { return _role; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Role cannot be null or empty.");
                }
                _role = value;
            }
        }
        public string Description
        {
            get { return _decription; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Description cannot be null or empty.");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException(nameof(value), "Description must be at least 2 characters long.");
                }
                _decription = value;
            }
        }
        public string Difficulty
        {
            get { return _difficulty; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Difficulty cannot be null or empty.");
                }
                _difficulty = value;
            }
        }
        public DateTime ReleaseDate { get; set; }

        public Champion(int id, string name, string role, string description, string difficulty, DateTime releaseDate)
        {
            Id = id;
            Name = name;
            Role = role;
            Description = description;
            Difficulty = difficulty;
            ReleaseDate = releaseDate;
        }
        public Champion() { }

    }
}
