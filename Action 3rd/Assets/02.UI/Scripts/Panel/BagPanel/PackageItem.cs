using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class PackageItem : MonoBehaviour, IPointerClickHandler
    {
        public event Action<PackageItem> OnClick;
        public Image iconImage;
        public StorableItemData StorableItemData;
        public TMP_Text levelText;

        public void OnPointerClick(PointerEventData eventData)
        {
            this.OnClick?.Invoke(this);
        }
    }
}