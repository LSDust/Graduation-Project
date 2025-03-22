using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class PackageItem : MonoBehaviour, IPointerClickHandler
    {
        public event Action<PackageItem> OnClick;
        public Image iconImage;
        public StorableItemData StorableItemData;
        [Tooltip("文本")] public TMP_Text itemText;

        public void OnPointerClick(PointerEventData eventData)
        {
            this.OnClick?.Invoke(this);
        }
    }
}