using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;

namespace Action3rd
{
    [CreateAssetMenu(fileName = "StorableItemInfoConfig.asset", menuName = "Action3rd/StorableItemInfoConfig")]
    public class StorableItemInfoConfig : SerializedScriptableObject
    {
        public Dictionary<string, StorableItemInfo> ItemInfos = new Dictionary<string, StorableItemInfo>();
    }

    [Serializable]
    public class StorableItemInfo
    {
        public string id;
        public Sprite icon;
        public string name;
        public string description;

        public StorableItemType type; //这是不用展示文本的信息
    }

    public enum StorableItemType { 武器 = 1, 食物 }

    public class StorableItemData
    {
        public readonly string InfoIndex;

        //动态数据
        public readonly string ItmId;
        public int Durability;
        public int Quantity;

        public StorableItemData(string infoIndex, string itmId, int durability = 100, int quantity = 1)
        {
            InfoIndex = infoIndex;
            ItmId = itmId;
            Durability = durability;
            Quantity = quantity;
        }
    }
}