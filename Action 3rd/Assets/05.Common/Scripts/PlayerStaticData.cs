using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Action3rd
{
    public static class PlayerStaticData
    {
        private static StorableItemInfoConfig _storableItemInfoConfig;

        public static StorableItemInfoConfig StorableItemInfoConfig => _storableItemInfoConfig ??=
            Resources.Load<StorableItemInfoConfig>($"StorableItemInfoConfig");
        // {
        //     get
        //     {
        //         if (_storableItemInfoConfig == null)
        //         {
        //             _storableItemInfoConfig = Resources.Load<StorableItemInfoConfig>($"StorableItemInfoConfig");
        //         }
        //
        //         return _storableItemInfoConfig;
        //     }
        // }
    }
}