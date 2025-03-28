using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Action3rd.UI
{
    /// <summary>
    /// 背包面板下的功能
    /// </summary>
    public class BagPanel : BasePanel
    {
        [SerializeField] private Button exitButton;
        [SerializeField] private TMP_Text title;

        [SerializeField] [Tooltip("在ToggleGroup上")]
        private SelectedToggle selectedToggle;

        [SerializeField] private PackageItemDetail packageItemDetail;

        [SerializeField] [Tooltip("所有种类的物品窗口")]
        private GameObject[] packageItemViews;

        private int _currentTypeID = 0;
        private PackageItem _currentItem;


        private void Awake()
        {
            exitButton.onClick.AddListener(CloseBagPanel);
            selectedToggle.OnSelectedToggle += t => title.text = t.name;
            selectedToggle.OnSelectedToggle += TabChanged;
            for (int i = 0; i < packageItemViews.Length; i++)
            {
                packageItemViews[i].GetComponent<PackageItemView>().CurrentItemChanged += SetCurrentItem;
            }
        }

        private void CloseBagPanel()
        {
            PanelManager.ClosePanel();
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        private void TabChanged(Toggle toggle)
        {
            this.packageItemViews[_currentTypeID].SetActive(false);
            this._currentTypeID = toggle.name switch
            {
                "武器" => 0,
                "食物" => 1,
                _ => this._currentTypeID
            };
            this.packageItemViews[_currentTypeID].SetActive(true);
        }

        private void SetCurrentItem(PackageItem item)
        {
            this._currentItem = item;
            packageItemDetail.ShowDetail(_currentItem.StorableItemData);
        }


        public void Consume()
        {
            this._currentItem.StorableItemData.Quantity--;
            if (this._currentItem.StorableItemData.Quantity == 0)
            {
                PlayerDynamicData.PackageItemDataDic.Remove(this._currentItem.StorableItemData.ItmId);
                // Refresh();
            }
            else
            {
                this._currentItem.itemText.text = this._currentItem.StorableItemData.Quantity.ToString();
            }
        }

        public void Equip()
        {
            Debug.Log("装备" + this._currentItem.StorableItemData.ItemInfoIndex);
        }
    }
}