using System;
using System.Collections.Generic;
using UnityEngine;

namespace Action3rd
{
    public class StorableItemData
    {
        public int ItemInfoIndex;

        //动态数据
        public string ItmId;
        public bool IsNew;
        public int Quantity;
        public int WeaponLevel;

        public StorableItemData(int itemInfoIndex, string itmId, int level = 0, bool isNew = true)
        {
            ItemInfoIndex = itemInfoIndex;
            ItmId = itmId;
            WeaponLevel = level;
            IsNew = isNew;
        }
    }

    [CreateAssetMenu(fileName = "StorableItemInfoConfig.asset", menuName = "Action3rd/StorableItemInfoConfig")]
    public class StorableItemInfoConfig : ScriptableObject
    {
        public List<StorableItemInfo> items = new List<StorableItemInfo>();

        private void OnValidate()
        {
//             foreach (StorableItemInfo ii in items)
//             {
//                 if (ii.itemIcon != null)
//                 {
//                     ii.fileName = ii.itemIcon.name;
// // #if UNITY_EDITOR
//                     // ii.atlasPath = UnityEditor.AssetDatabase.GetAssetPath(ii.itemIcon);
// // #endif
//                 }
//                 else
//                 {
//                     ii.fileName = string.Empty;
//                     // ii.atlasPath = string.Empty;
//                 }
//             }
        }
    }

    [Serializable]
    public class StorableItemInfo
    {
        // [HideInInspector] public string fileName;
        public Sprite itemIcon;
        public string itemName;
        public StorableItemType storableItemType;
        public string description;
    }

    public enum StorableItemType { 武器, 食物 }
}