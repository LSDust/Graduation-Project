using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Action3rd
{
    public static class PlayerDynamicData
    {
        public static List<StorableItemData> PackageItemDatas = new List<StorableItemData>();
        private static readonly string FilePath = Path.Combine(Application.persistentDataPath, "PackageItemDatas.json");

        public static void GetPackageItemData()
        {
            PackageItemDatas =
                Newtonsoft.Json.JsonConvert.DeserializeObject<List<StorableItemData>>(
                    LocalFileStreamIO.ReadStringFromFile(FilePath));
        }


        public static void SavePackageItemData()
        {
            string jsonData =
                Newtonsoft.Json.JsonConvert.SerializeObject(PackageItemDatas, Newtonsoft.Json.Formatting.Indented);
            LocalFileStreamIO.WriteStringToFile(FilePath, jsonData);
        }
    }

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
}