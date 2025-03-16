using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class BagPanel : BasePanel
    {
        [SerializeField] private Button exitButton;
        [SerializeField] private TMP_Text title;

        [SerializeField] [Tooltip("在ToggleGroup上")]
        private SelectedToggle selectedToggle;


        private void Awake()
        {
            exitButton.onClick.AddListener(CloseBagPanel);
            selectedToggle.OnSelectedToggle += t => title.text = t.name;
            selectedToggle.OnSelectedToggle += GetComponentInChildren<PackageItemManager>().TabChanged;
        }

        private void CloseBagPanel()
        {
            PanelManager.ClosePanel();
        }
    }
}