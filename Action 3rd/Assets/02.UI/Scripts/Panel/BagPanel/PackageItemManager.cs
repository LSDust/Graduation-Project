using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class PackageItemManager : MonoBehaviour
    {
        [SerializeField] private PackageItem packageItemPrefab;
        private StorableItemType _tabPage = StorableItemType.武器;
        public SpriteAtlas spriteAtlas;

        public StorableItemInfoConfig storableItemInfoConfig;

        private void OnDisable()
        {
            // PlayerDynamicData.SavePackageItemData();
        }

        public void Refresh()
        {
            Clear();
            SpawnItem();
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
            for (int i = 0; i < PlayerDynamicData.PackageItemDataList.Count; i++)
            {
                StorableItemInfo storableItemInfo =
                    storableItemInfoConfig.items[PlayerDynamicData.PackageItemDataList[i].ItemInfoIndex];
                if (storableItemInfo.storableItemType != _tabPage)
                {
                    continue;
                }

                PackageItem pi = Instantiate<PackageItem>(packageItemPrefab, this.transform);
                pi.StorableItemData = PlayerDynamicData.PackageItemDataList[i];
                pi.iconImage.sprite = spriteAtlas.GetSprite(storableItemInfo.fileName);
                if (storableItemInfo.storableItemType == StorableItemType.武器)
                {
                    pi.levelText.text = "Lv." + pi.StorableItemData.WeaponLevel.ToString();
                }
                else
                {
                    pi.iconImage.transform.rotation = Quaternion.identity;
                    pi.levelText.text = pi.StorableItemData.Quantity.ToString();
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
    }
}