using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Action3rd
{
    public static class PlayerStaticData
    {
        private static StorableItemInfoConfig _storableItemInfoConfig;

        public static StorableItemInfoConfig StorableItemInfoConfig => _storableItemInfoConfig ??=
            Resources.Load<StorableItemInfoConfig>($"StorableItemInfoConfig");

        public static string GetRandomKey()
        {
            int randomIndex = Random.Range(0, StorableItemInfoConfig.ItemInfos.Count);
            return StorableItemInfoConfig.ItemInfos.Keys.ElementAt(randomIndex);
        }
    }
}