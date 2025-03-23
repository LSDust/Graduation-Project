using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Action3rd
{
    public class TestJson : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // long date = DateTime.UtcNow.Ticks;
            // PlayerDynamicData.StorableItemDict.Add(ItemDataType.Weapon, new List<StorableItemData>());
            // List<StorableItemData> items = new List<StorableItemData>() { new StorableItemData(1, date.ToString()) };
            // PlayerDynamicData.PackageItemDataDic.Add(new StorableItemData(0, date.ToString()));
            // PlayerDynamicData.PackageItemDataDic.Add(new StorableItemData(1, date.ToString()));
            // PlayerDynamicData.PackageItemDataDic.Add(new StorableItemData(2, date.ToString()));
            // PlayerDynamicData.PackageItemDataDic.Add(new StorableItemData(3, date.ToString()));
            // PlayerDynamicData.PackageItemDataDic.Add(new StorableItemData(4, date.ToString()));
            // PlayerDynamicData.PackageItemDataDic.Add(new StorableItemData(5, date.ToString()));
            // PlayerDynamicData.PackageItemDataDic.Add(new StorableItemData(6, date.ToString()));
            // PlayerDynamicData.SavePackageItemData();
            // Debug.Log(date);
            // string id = Guid.NewGuid().ToString();
            // PlayerDynamicData.PackageItemDataDic.Add(id, new StorableItemData(0, id));
            // id = Guid.NewGuid().ToString();
            // PlayerDynamicData.PackageItemDataDic.Add(id, new StorableItemData(1, id));
            // id = Guid.NewGuid().ToString();
            // PlayerDynamicData.PackageItemDataDic.Add(id, new StorableItemData(2, id));
            // id = Guid.NewGuid().ToString();
            // PlayerDynamicData.PackageItemDataDic.Add(id, new StorableItemData(3, id));
            // id = Guid.NewGuid().ToString();
            // PlayerDynamicData.PackageItemDataDic.Add(id, new StorableItemData(4, id));
            // id = Guid.NewGuid().ToString();
            // PlayerDynamicData.PackageItemDataDic.Add(id, new StorableItemData(5, id));
            // id = Guid.NewGuid().ToString();
            // PlayerDynamicData.PackageItemDataDic.Add(id, new StorableItemData(6, id));
            PlayerDynamicData.ObtainItem(20);
            PlayerDynamicData.SavePackageItemData();
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}