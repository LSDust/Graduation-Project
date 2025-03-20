using Action3rd.UI;
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

        public void ShowDetail(StorableItemData storableItemData)
        {
            this.itemName.text = storableItemData.ItemInfoIndex.ToString();
        }
    }
}