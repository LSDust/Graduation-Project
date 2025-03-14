using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;

namespace Action3rd.UI
{
    public class PackageItemManager : MonoBehaviour
    {
        [SerializeField] private PackageItem packageItemPrefab;
        private ItemType _tabPage = ItemType.武器;
        public SpriteAtlas spriteAtlas;
        public ItemInfoConfig itemInfoConfig;

        private List<PackageItemData> _packageItemDatas = new List<PackageItemData>()
        {
            new PackageItemData(0, "4fr2rdwf", 1),
            new PackageItemData(1, "e3223wrw", 1),
            new PackageItemData(0, "4fr2rasf", 1),
            new PackageItemData(1, "e32nkwrw", 1)
        };

        private void OnEnable()
        {
            for (int i = 0; i < _packageItemDatas.Count; i++)
            {
                ItemInfo itemInfo = itemInfoConfig.items[_packageItemDatas[i].ItemInfoIndex];
                if (itemInfo.itemType != _tabPage)
                {
                    continue;
                }

                PackageItem pi = Instantiate<PackageItem>(packageItemPrefab, this.transform);
                pi.PackageItemData = _packageItemDatas[i];
                pi.iconImage.sprite = spriteAtlas.GetSprite(itemInfo.fileName);
                pi.levelText.text = "Lv." + pi.PackageItemData.Level.ToString();
            }
        }

        private void OnDisable()
        {
        }

        public void Refresh()
        {
            // Clear();
            // SpawnItem(itemDataList.ItemDatas);
        }
    }
}