using Assets.Scripts.Exceptions;

namespace Assets.Scripts.GameData.StaticData
{
    public class ArenaData
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public int Width { get; }
        public int Height { get; }

        public ArenaData(
            int id,
            string name,
            string description,
            int width,
            int height)
        {
            if (id <= 0)
                throw new InvalidArenaStateException("Arena ID must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidArenaStateException("Arena name cannot be empty.");

            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidArenaStateException("Arena description cannot be empty.");

            if (width <= 0)
                throw new InvalidArenaStateException("Arena width must be greater than zero.");

            if (height <= 0)
                throw new InvalidArenaStateException("Arena height must be greater than zero.");

            Id = id;
            Name = name;
            Description = description;
            Width = width;
            Height = height;
        }
    }
}
