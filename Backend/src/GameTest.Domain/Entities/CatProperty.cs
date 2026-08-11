using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Entities
{
    public class CatProperty
    {
        public int Id { get; private set; }
        public int CatId { get; private set; }
        public Cat Cat { get; private set; } = null!;
        public int StatId { get; private set; }
        public CatStat Stat { get; private set; } = null!;
        public float Value { get; private set; }

        private CatProperty() { }

        public CatProperty(
            CatStat stat,
            float value)
        {
            if (stat == null)
                throw new DomainException("Cat stat cannot be null.");

            if (value < 0)
                throw new DomainException("Value cannot be negative.");

            StatId = stat.Id;
            Stat = stat;
            Value = value;
        }
    }
}
