using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Action3rd.UI
{
    /// <summary>
    /// 内聚背包物品的所有逻辑
    /// </summary>
    public class PackageItemManager : MonoBehaviour
    {
        [SerializeField] [Tooltip("单元格预制体")] private PackageItem packageItemPrefab;
        private StorableItemType _tabPage = StorableItemType.武器;
        [SerializeField] [Tooltip("详情面板")] private PackageItemDetail packageItemDetail;
        [SerializeField] [Tooltip("使用按钮")] private Button useButton;

        //1.一开始显示详情面板用,2.消耗时也要用
        private PackageItem _currentItem;

        private StorableItemInfoConfig _storableItemInfoConfig;
        // public SpriteAtlas spriteAtlas;

        private void Awake()
        {
            _storableItemInfoConfig = Resources.Load<StorableItemInfoConfig>($"StorableItemInfoConfig");
        }

        private void OnDisable()
        {
            PlayerDynamicData.SavePackageItemData();
        }

        public void Refresh()
        {
            Clear();
            SpawnItem();
            //todo:前面的修改要等到下一帧才实现吗
            Invoke($"SetFirstItem", 0.01f);
            UseButtonRefresh();
        }

        private void SetFirstItem()
        {
            Transform firstItem = this.transform.GetChild(0);
            if (firstItem != null)
            {
                _currentItem = firstItem.GetComponent<PackageItem>();
                packageItemDetail.ShowDetail(_currentItem.StorableItemData);
            }
        }

        private void Clear()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                //todo:是否用对象池
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        private void SpawnItem()
        {
            foreach (var t in PlayerDynamicData.PackageItemDataDic)
            {
                StorableItemInfo storableItemInfo =
                    _storableItemInfoConfig.items[t.Value.ItemInfoIndex]; //通过动态数据拿到静态数据
                if (storableItemInfo.storableItemType != _tabPage)
                {
                    continue;
                }

                PackageItem pi = Instantiate<PackageItem>(packageItemPrefab, this.transform);
                pi.OnClick += (x) => this._currentItem = x;
                pi.OnClick += (_) => packageItemDetail.ShowDetail(this._currentItem.StorableItemData);
                pi.StorableItemData = t.Value; //赋值数据
                pi.iconImage.sprite = storableItemInfo.itemIcon; //spriteAtlas.GetSprite(storableItemInfo.fileName);
                if (storableItemInfo.storableItemType == StorableItemType.武器)
                {
                    pi.itemText.text = pi.StorableItemData.Durability.ToString() + "%";
                }
                else
                {
                    pi.iconImage.transform.rotation = Quaternion.identity;
                    pi.itemText.text = pi.StorableItemData.Quantity.ToString();
                }
            }
        }

        public void TabChanged(Toggle toggle)
        {
            this._tabPage = toggle.name switch
            {
                "武器" => StorableItemType.武器,
                "食物" => StorableItemType.食物,
                _ => this._tabPage
            };

            this.Refresh();
        }

        private void UseButtonRefresh()
        {
            useButton.onClick.RemoveAllListeners();
            switch (this._tabPage)
            {
                case StorableItemType.武器:
                    useButton.GetComponentInChildren<TMP_Text>().text = "装备";
                    useButton.onClick.AddListener(Equip);
                    break;
                case StorableItemType.食物:
                    useButton.GetComponentInChildren<TMP_Text>().text = "使用";
                    useButton.onClick.AddListener(Consume);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Consume()
        {
            this._currentItem.StorableItemData.Quantity--;
            if (this._currentItem.StorableItemData.Quantity == 0)
            {
                PlayerDynamicData.PackageItemDataDic.Remove(this._currentItem.StorableItemData.ItmId);
                Refresh();
            }
            else
            {
                this._currentItem.itemText.text = this._currentItem.StorableItemData.Quantity.ToString();
            }
        }

        private void Equip()
        {
            Debug.Log("装备" + this._currentItem.StorableItemData.ItemInfoIndex);
        }
    }
}