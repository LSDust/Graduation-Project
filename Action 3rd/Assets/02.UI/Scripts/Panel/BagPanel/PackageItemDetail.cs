using Action3rd.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Action3rd
{
    public class PackageItemDetail : MonoBehaviour
    {
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private Image itemIcon;
        [SerializeField] private TMP_Text itemStory;

        private StorableItemInfoConfig _storableItemInfoConfig;

        private void Awake()
        {
            _storableItemInfoConfig = Resources.Load<StorableItemInfoConfig>($"StorableItemInfoConfig");
        }

        public void ShowDetail(StorableItemData storableItemData)
        {
            this.itemName.text = _storableItemInfoConfig.ItemInfos[storableItemData.InfoIndex].name;
            this.itemIcon.sprite = _storableItemInfoConfig.ItemInfos[storableItemData.InfoIndex].icon;
            this.itemStory.text = _storableItemInfoConfig.ItemInfos[storableItemData.InfoIndex].description;
        }
    }
}