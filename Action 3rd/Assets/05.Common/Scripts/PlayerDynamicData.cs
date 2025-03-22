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

        private static Dictionary<string, StorableItemData> _packageItemDataDic;

        public static Dictionary<string, StorableItemData> PackageItemDataDic => _packageItemDataDic ??=
            Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, StorableItemData>>
            (
                LocalFileStreamIO.ReadStringFromFile(FilePath)
            );

        public static void SavePackageItemData()
        {
            string jsonData =
                Newtonsoft.Json.JsonConvert.SerializeObject(PackageItemDataDic, Newtonsoft.Json.Formatting.Indented);
            LocalFileStreamIO.WriteStringToFile(FilePath, jsonData);
        }

        public static void UpdatePackageItemData(string itemId, StorableItemData item)
        {
        }
    }
}