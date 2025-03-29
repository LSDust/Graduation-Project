using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Action3rd.UI
{
    /// <summary>
    /// 管理窗口内的背包物品
    /// </summary>
    public class PackageItemView0 : MonoBehaviour
    {
        [SerializeField] [Tooltip("单元格预制体")] private PackageItem packageItemPrefab;
        // [SerializeField] [Tooltip("物品类型")] private StorableItemType tabPage = StorableItemType.武器;

        //1.一开始显示详情面板用,2.消耗时也要用
        private PackageItem _currentItem;

        // [SerializeField] [Tooltip("预制体")] private GameObject prefab;
        // public GameObject Prefab => prefab;
        // [SerializeField] [Tooltip("详情面板")] private PackageItemDetail packageItemDetail { get; }
        // [SerializeField] [Tooltip("使用按钮")] private Button useButton { get; }
        // public SpriteAtlas spriteAtlas;

        private void OnEnable()
        {
            Refresh();
        }

        private void OnDisable()
        {
            PlayerDynamicData.SavePackageItemData();
        }

        private void Refresh()
        {
            Clear();
            SpawnItem();
            //todo:前面的修改要等到下一帧才实现吗
            Invoke($"SetFirstItem", 0.01f);
            // SetFirstItem();
            // UseButtonRefresh();
        }

        private void SetFirstItem()
        {
            Transform firstItem = this.transform.GetChild(0);
            if (firstItem != null)
            {
                _currentItem = firstItem.GetComponent<PackageItem>();
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
            // foreach (var t in PlayerDynamicData.PackageItemDataDic)
            // {
            //     StorableItemInfo storableItemInfo =
            //         PlayerStaticData.StorableItemInfoConfig.ItemInfos[t.Value.ItemInfoIndex]; //通过动态数据拿到静态数据
            //     if (storableItemInfo.storableItemType != tabPage)
            //     {
            //         continue;
            //     }
            //
            //     PackageItem pi = Instantiate<PackageItem>(packageItemPrefab, this.transform);
            //     pi.OnClick += (x) => this._currentItem = x;
            //     //todo:该类不再调用Detail
            //     // pi.OnClick += (_) => packageItemDetail.ShowDetail(this._currentItem.StorableItemData);
            //     pi.StorableItemData = t.Value; //赋值数据
            //     pi.iconImage.sprite = storableItemInfo.icon; //spriteAtlas.GetSprite(storableItemInfo.fileName);
            //     if (storableItemInfo.storableItemType == StorableItemType.武器)
            //     {
            //         pi.itemText.text = pi.StorableItemData.Durability.ToString() + "%";
            //     }
            //     else
            //     {
            //         pi.itemText.text = pi.StorableItemData.Quantity.ToString();
            //     }
            // }
        }

        // public void TabChanged(Toggle toggle)
        // {
        //     this.tabPage = toggle.name switch
        //     {
        //         "武器" => StorableItemType.武器,
        //         "食物" => StorableItemType.食物,
        //         _ => this.tabPage
        //     };
        //
        //     this.Refresh();
        // }

        //todo:该类不再调用装备Button
        // private void UseButtonRefresh()
        // {
        //     useButton.onClick.RemoveAllListeners();
        //     switch (this._tabPage)
        //     {
        //         case StorableItemType.武器:
        //             useButton.GetComponentInChildren<TMP_Text>().text = "装备";
        //             useButton.onClick.AddListener(Equip);
        //             break;
        //         case StorableItemType.食物:
        //             useButton.GetComponentInChildren<TMP_Text>().text = "使用";
        //             useButton.onClick.AddListener(Consume);
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        // }

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
            Debug.Log("装备" + this._currentItem.StorableItemData.InfoIndex);
        }
    }
}