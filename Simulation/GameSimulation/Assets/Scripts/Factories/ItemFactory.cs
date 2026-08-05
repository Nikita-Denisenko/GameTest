using Assets.Scripts.Entities;
using Assets.Scripts.GameData.Runs;
using Assets.Scripts.StaticData;
using Assets.Scripts.ValueObjects;
using System.Linq;

namespace Assets.Scripts.Factories
{
    public class ItemFactory
    {
        public Item Create(
            RunItemData runItemData,
            ItemData itemData)
        {
            var levels = itemData.TemporaryLevels
                .Select(x => new ItemUpgradeLevel(
                    x.Level,
                    x.Bonus,
                    x.Price))
                .ToList();

            return new Item(
                itemData.Id,
                itemData.Name,
                itemData.Type,
                itemData.Effect.Type,
                runItemData.Bonus,
                levels);
        }
    }
}
