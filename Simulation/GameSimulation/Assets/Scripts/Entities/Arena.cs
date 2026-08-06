using Assets.Scripts.Exceptions;

namespace Assets.Scripts.Entities
{
    public class Arena
    {
        public int Id { get; }
        public string Name { get; }
        public int Width { get; }
        public int Height { get; }

        public Arena(
            int id,
            string name,
            int width,
            int height)
        {
            if (id <= 0)
                throw new InvalidArenaStateException("Arena ID must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidArenaStateException("Arena name cannot be empty.");

            if (width <= 0)
                throw new InvalidArenaStateException("Arena width must be greater than zero.");

            if (height <= 0)
                throw new InvalidArenaStateException("Arena height must be greater than zero.");

            Id = id;
            Name = name;
            Width = width;
            Height = height;
        }
    }
}
