using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities
{
    public class Arena
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public float Width { get; private set; }
        public float Height { get; private set; }

        public Arena(
            string name, 
            string description, 
            float width, 
            float height)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Arena name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Arena description cannot be null or empty.");

            if (width <= 0)
                throw new DomainException("Arena width must be a positive value.");

            if (height <= 0)
                throw new DomainException("Arena height must be a positive value.");

            Name = name;
            Description = description;
            Width = width;
            Height = height;
        }
    }
}
