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

        [SerializeField] [Tooltip("使用按钮")] private Button[] useButtons;

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

        public override void OnEnter()
        {
            base.OnEnter();
            Time.timeScale = 0f;
            this.packageItemViews[_currentTypeID].GetComponent<PackageItemView>().Refresh();
        }

        public override void OnExit()
        {
            base.OnExit();
            Time.timeScale = 1f;
        }

        private void CloseBagPanel()
        {
            PanelManager.ClosePanel();
        }

        private void OnDestroy()
        {
            PlayerDynamicData.SavePackageItemData();
        }

        private void TabChanged(Toggle toggle)
        {
            this.packageItemViews[_currentTypeID].SetActive(false);
            this.useButtons[_currentTypeID].gameObject.SetActive(false);
            this._currentTypeID = toggle.name switch
            {
                "武器" => 0,
                "食物" => 1,
                _ => this._currentTypeID
            };
            this.packageItemViews[_currentTypeID].SetActive(true);
            this.useButtons[_currentTypeID].gameObject.SetActive(true);
        }

        private void SetCurrentItem(PackageItem item)
        {
            this._currentItem = item;
            packageItemDetail.ShowDetail(_currentItem.StorableItemData);
        }


        public void Consume()
        {
            this._currentItem.StorableItemData.Quantity--;
            GameObject.FindWithTag("Player").GetComponent<WithHp>().hp += 20;
            if (this._currentItem.StorableItemData.Quantity == 0)
            {
                StorableItemType type = PlayerStaticData.StorableItemInfoConfig
                    .ItemInfos[this._currentItem.StorableItemData.InfoIndex].type;
                PlayerDynamicData.PackageItemDataDic[type].Remove(this._currentItem.StorableItemData);
                this.packageItemViews[_currentTypeID].GetComponent<PackageItemView>().Refresh();
            }
            else
            {
                this._currentItem.itemText.text = this._currentItem.StorableItemData.Quantity.ToString();
            }
        }

        public void Equip()
        {
            Debug.Log("装备" + this._currentItem.StorableItemData.InfoIndex);
            PlayerDynamicData.PlayerState.Weapon = this._currentItem.StorableItemData;
            this.packageItemViews[_currentTypeID].GetComponent<PackageItemView>().Refresh();
        }
    }
}