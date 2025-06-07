using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class PackageItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("子物体")] public Image iconImage;
        public Image isEquip;
        public GameObject selectedEdge;
        [Tooltip("文本")] public TMP_Text itemText;

        [Header("数据")] public StorableItemData StorableItemData;
        public event Action<PackageItem> OnClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            this.OnClick?.Invoke(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            this.selectedEdge.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.selectedEdge.SetActive(false);
        }
    }
}