using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Action3rd
{
    [CreateAssetMenu(fileName = "ItemInfoConfig.asset", menuName = "Action3rd/ItemInfoConfig")]
    public class ItemInfoConfig : ScriptableObject
    {
        public List<ItemInfo> items = new List<ItemInfo>();

        private void OnValidate()
        {
            foreach (ItemInfo ii in items)
            {
                if (ii.itemIcon != null)
                {
                    ii.fileName = ii.itemIcon.name;
// #if UNITY_EDITOR
                    // ii.atlasPath = UnityEditor.AssetDatabase.GetAssetPath(ii.itemIcon);
// #endif
                }
                else
                {
                    ii.fileName = string.Empty;
                    // ii.atlasPath = string.Empty;
                }
            }
        }
    }

    [Serializable]
    public class ItemInfo
    {
        [HideInInspector] public string fileName;
        public Sprite itemIcon;
        public string itemName;
        public ItemType itemType;
        public string description;
    }

    public enum ItemType { 武器, 食物 }
}