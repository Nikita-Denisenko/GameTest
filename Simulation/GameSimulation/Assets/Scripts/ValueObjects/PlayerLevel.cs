namespace Assets.Scripts.ValueObjects
{
    public class PlayerLevel
    {
        public int Experience { get; }
        public int Level { get; }

        public PlayerLevel(int experience, int level) 
        {
            Experience = experience;
            Level = level;
        }
    }
}
