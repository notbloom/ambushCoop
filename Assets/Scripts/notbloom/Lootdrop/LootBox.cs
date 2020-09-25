using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace notbloom.Lootdrop
{
    public class LootBox<T>
    {
        public List<LootItem<T>> items;

        public T Roll()
        {
            int totalWeight = WeightsSum();
            int weightRoll = UnityEngine.Random.Range(0, totalWeight);
            int currentWeight = 0;
            foreach (LootItem<T> item in items)
            {
                currentWeight += item.weight;
                if (weightRoll < currentWeight)
                    return item.item;
            }
            return default(T);
        }
        private int WeightsSum()
        {
            int totalWeight = 0;
            foreach (LootItem<T> item in items)
            {
                totalWeight += item.weight;
            }
            return totalWeight;
        }
    }
}