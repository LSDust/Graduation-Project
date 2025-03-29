using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Action3rd
{
    /// <summary>
    /// 数据类,玩家所有的动态数据
    /// </summary>
    public static class PlayerDynamicData
    {
        private static readonly string FilePath = Path.Combine(Application.persistentDataPath, "PackageItemDatas.json");

        private static Dictionary<StorableItemType, List<StorableItemData>> _packageItemDataDic;

        public static Dictionary<StorableItemType, List<StorableItemData>> PackageItemDataDic => _packageItemDataDic ??=
            Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<StorableItemType, List<StorableItemData>>>
            (
                LocalFileStreamIO.ReadStringFromFile(FilePath)
            ) ?? new Dictionary<StorableItemType, List<StorableItemData>>()
            {
                { StorableItemType.武器, new List<StorableItemData>() },
                { StorableItemType.食物, new List<StorableItemData>() }
            };

        public static void SavePackageItemData()
        {
            string jsonData =
                Newtonsoft.Json.JsonConvert.SerializeObject(PackageItemDataDic, Newtonsoft.Json.Formatting.Indented);
            LocalFileStreamIO.WriteStringToFile(FilePath, jsonData);
        }

        public static void UpdatePackageItemData(string itemId, StorableItemData item)
        {
        }

        //todo:infoIndex从静态数据字典的key中随机生成
        // public static void ObtainItem(int infoIndex)
        // {
        //     StorableItemInfoConfig info = Resources.Load<StorableItemInfoConfig>($"StorableItemInfoConfig");
        //     if (info.ItemInfos[infoIndex].storableItemType == StorableItemType.武器)
        //     {
        //         string id = Guid.NewGuid().ToString();
        //         PlayerDynamicData.PackageItemDataDic.Add(id, new StorableItemData(infoIndex, id));
        //     }
        //     else if (info.ItemInfos[infoIndex].storableItemType == StorableItemType.食物)
        //     {
        //         if (PlayerDynamicData.PackageItemDataDic.ContainsKey(infoIndex.ToString()))
        //         {
        //             PlayerDynamicData.PackageItemDataDic[infoIndex.ToString()].Quantity++;
        //         }
        //         else
        //         {
        //             PlayerDynamicData.PackageItemDataDic.Add(infoIndex.ToString(),
        //                 new StorableItemData(infoIndex, infoIndex.ToString()));
        //         }
        //     }
        // }
    }
}