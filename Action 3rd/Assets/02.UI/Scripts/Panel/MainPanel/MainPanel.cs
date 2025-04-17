using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class MainPanel : BasePanel
    {
        [SerializeField] private Button bagButton;

        [SerializeField] private Button settingButton;

        [SerializeField] private Slider playerHpBar;
        private WithHp playerHp;

        private void Awake()
        {
            settingButton.onClick.AddListener(OpenSettingPanel);
            bagButton.onClick.AddListener(OpenBagPanel);
            this.playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<WithHp>();
        }

        private void Update()
        {
            this.playerHpBar.value = this.playerHp.hp;
        }

        private void OpenSettingPanel()
        {
            PanelManager.OpenPanel(PanelKey.Setting);
        }

        private void OpenBagPanel()
        {
            PanelManager.OpenPanel(PanelKey.Bag);
        }
    }
}