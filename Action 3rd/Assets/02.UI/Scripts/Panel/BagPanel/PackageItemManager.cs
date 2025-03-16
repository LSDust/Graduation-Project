using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class PackageItemManager : MonoBehaviour
    {
        [SerializeField] private PackageItem packageItemPrefab;
        private ItemType _tabPage = ItemType.武器;
        public SpriteAtlas spriteAtlas;
        public ItemInfoConfig itemInfoConfig;

        private void OnEnable()
        {
            PlayerDynamicData.GetPackageItemData();
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
        }

        private void Clear()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        private void SpawnItem()
        {
            for (int i = 0; i < PlayerDynamicData.PackageItemDatas.Count; i++)
            {
                ItemInfo itemInfo = itemInfoConfig.items[PlayerDynamicData.PackageItemDatas[i].ItemInfoIndex];
                if (itemInfo.itemType != _tabPage)
                {
                    continue;
                }

                PackageItem pi = Instantiate<PackageItem>(packageItemPrefab, this.transform);
                pi.StorableItemData = PlayerDynamicData.PackageItemDatas[i];
                pi.iconImage.sprite = spriteAtlas.GetSprite(itemInfo.fileName);
                if (itemInfo.itemType == ItemType.武器)
                {
                    pi.levelText.text = "Lv." + pi.StorableItemData.WeaponLevel.ToString();
                }
                else
                {
                    pi.levelText.text = pi.StorableItemData.Quantity.ToString();
                }
            }
        }

        public void TabChanged(Toggle toggle)
        {
            if (toggle.name == "武器")
            {
                this._tabPage = ItemType.武器;
            }
            else if (toggle.name == "食物")
            {
                this._tabPage = ItemType.食物;
            }

            this.Refresh();
        }
    }
}