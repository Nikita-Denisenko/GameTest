using Assets.Scripts.Game;
using Assets.Scripts.GameData;
using Assets.Scripts.GameData.Runs;
using System;

namespace Assets.Scripts.Factories
{
    public class RunFactory
    {
        private readonly Catalog _catalog;

        private readonly UnitFactory _unitFactory;
        private readonly WeaponFactory _weaponFactory;
        private readonly ItemFactory _itemFactory;
        private readonly WaveFactory _waveFactory;


        public RunFactory(
            Catalog catalog,
            UnitFactory unitFactory,
            WeaponFactory weaponFactory,
            ItemFactory itemFactory,
            WaveFactory waveFactory)
        {
            _catalog = catalog;
            _unitFactory = unitFactory;
            _weaponFactory = weaponFactory;
            _itemFactory = itemFactory;
            _waveFactory = waveFactory;
        }


        public GameSession Create(
            RunPreparationData preparation)
        {
            throw new NotImplementedException();
        }
    }
}