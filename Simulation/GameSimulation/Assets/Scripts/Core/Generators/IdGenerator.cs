using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Core.Generators
{
    public class IdGenerator : IIdGenerator
    {
        private int _currentId = 1;

        public int Generate()
        {
            return _currentId++;
        }
    }
}
