using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Action3rd.UI
{
    public class PackageItemView : MonoBehaviour
    {
        [SerializeField] [Tooltip("单元格预制体")] private PackageItem packageItemPrefab;
        [SerializeField] [Tooltip("物品类型")] private StorableItemType tabPage = StorableItemType.武器;

        [SerializeField] private Transform content;

        public event Action<PackageItem> CurrentItemChanged;

        private void OnEnable()
        {
            Refresh();
        }

        private void SetCurrentItem(PackageItem item)
        {
            CurrentItemChanged?.Invoke(item);
        }

        private void Refresh()
        {
            Clear();
            SpawnItem();
            SetFirstItem();
        }

        private void SetFirstItem()
        {
            Transform firstItem = this.content.GetChild(0);
            if (firstItem != null)
            {
                SetCurrentItem(firstItem.GetComponent<PackageItem>());
            }
        }

        private void Clear()
        {
            for (int i = content.childCount - 1; i >= 0; i--)
            {
                //todo:是否用对象池
                Destroy(content.transform.GetChild(i).gameObject);
            }
        }

        private void SpawnItem()
        {
            foreach (var t in PlayerDynamicData.PackageItemDataDic)
            {
                StorableItemInfo storableItemInfo =
                    PlayerStaticData.StorableItemInfoConfig.ItemInfos[t.Value.InfoIndex]; //通过动态数据拿到静态数据
                if (storableItemInfo.type != tabPage)
                {
                    continue;
                }

                PackageItem pi = Instantiate<PackageItem>(packageItemPrefab, this.content.transform);
                pi.OnClick += SetCurrentItem;
                pi.StorableItemData = t.Value; //赋值数据
                pi.iconImage.sprite = storableItemInfo.icon; //spriteAtlas.GetSprite(storableItemInfo.fileName);
                if (storableItemInfo.type == StorableItemType.武器)
                {
                    pi.itemText.text = pi.StorableItemData.Durability.ToString() + "%";
                }
                else
                {
                    pi.itemText.text = pi.StorableItemData.Quantity.ToString();
                }
            }
        }
    }
}