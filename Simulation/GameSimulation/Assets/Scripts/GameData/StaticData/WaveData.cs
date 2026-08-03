using Assets.Scripts.Exceptions;
using System.Collections.Generic;

namespace Assets.Scripts.StaticData
{
    public class WaveData
    {
        public int Id { get; }
        public int Number { get; }
        public int StartSecond { get; }
        public int EndSecond { get; }
        public IReadOnlyCollection<WaveEnemyData> Enemies { get; }

        public WaveData(
            int id,
            int number,
            int startSecond,
            int endSecond,
            IReadOnlyCollection<WaveEnemyData> enemies)
        {
            if (id <= 0)
                throw new InvalidWaveStateException("Wave id must be greater than zero.");

            if (number <= 0)
                throw new InvalidWaveStateException("Wave number must be greater than zero.");

            if (startSecond < 0)
                throw new InvalidWaveStateException("Start second cannot be negative.");

            if (endSecond <= startSecond)
                throw new InvalidWaveStateException("End second must be greater than start second.");

            Id = id;
            Number = number;
            StartSecond = startSecond;
            EndSecond = endSecond;
            Enemies = enemies ?? throw new InvalidWaveStateException("Enemies cannot be null.");
        }
    }
}
