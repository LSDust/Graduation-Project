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
        private static List<StorableItemData> _packageItemDataList;

        public static List<StorableItemData> PackageItemDataList => _packageItemDataList ??=
            Newtonsoft.Json.JsonConvert.DeserializeObject<List<StorableItemData>>
            (
                LocalFileStreamIO.ReadStringFromFile(FilePath)
            );

        private static readonly string FilePath = Path.Combine(Application.persistentDataPath, "PackageItemDatas.json");

        public static void SavePackageItemData()
        {
            string jsonData =
                Newtonsoft.Json.JsonConvert.SerializeObject(PackageItemDataList, Newtonsoft.Json.Formatting.Indented);
            LocalFileStreamIO.WriteStringToFile(FilePath, jsonData);
        }
    }
}