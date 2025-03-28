using System;
using System.Collections.Generic;
using UnityEngine;

namespace Action3rd
{
    [CreateAssetMenu(fileName = "StorableItemInfoConfig.asset", menuName = "Action3rd/StorableItemInfoConfig")]
    public class StorableItemInfoConfig : ScriptableObject
    {
        public List<StorableItemInfo> items = new List<StorableItemInfo>();
    }

    [Serializable]
    public class StorableItemInfo
    {
        public Sprite itemIcon;
        public string itemName;
        public StorableItemType storableItemType; //这是不用展示文本的信息
        public string description;
    }

    public enum StorableItemType { 武器, 食物 }

    public class StorableItemData
    {
        public readonly int ItemInfoIndex;

        //动态数据
        public readonly string ItmId;
        public int Durability;
        public int Quantity;

        public StorableItemData(int itemInfoIndex, string itmId, int durability = 100, int quantity = 1)
        {
            ItemInfoIndex = itemInfoIndex;
            ItmId = itmId;
            Durability = durability;
            Quantity = quantity;
        }
    }
}