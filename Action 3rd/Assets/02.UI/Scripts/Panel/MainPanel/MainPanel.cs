using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class MainPanel : BasePanel
    {
        [SerializeField] private Button bagButton;

        [SerializeField] private Button loadMainButton;
        [SerializeField] private Button loadDungeonButton;

        [SerializeField] private Button settingButton;

        [SerializeField] private Slider playerHpBar;
        private WithHp playerHp;

        private WithHp PlayerHp
        {
            get
            {
                if (playerHp == null)
                {
                    playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<WithHp>();
                }
                return playerHp;
            }
        }

        private void Awake()
        {
            settingButton.onClick.AddListener(OpenSettingPanel);
            bagButton.onClick.AddListener(OpenBagPanel);
            loadMainButton.onClick.AddListener(() => OpenLoadPanel(0));
            loadMainButton.onClick.AddListener(() =>
            {
                loadMainButton.gameObject.SetActive(false);
                loadDungeonButton.gameObject.SetActive(true);
            });
            loadDungeonButton.onClick.AddListener(() => OpenLoadPanel(1));
            loadDungeonButton.onClick.AddListener(() =>
            {
                loadMainButton.gameObject.SetActive(true);
                loadDungeonButton.gameObject.SetActive(false);
            });
            // this.playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<WithHp>();
        }

        private void Update()
        {
            this.playerHpBar.value = this.PlayerHp.hp;
        }

        private void OpenSettingPanel()
        {
            PanelManager.OpenPanel(PanelKey.Setting);
        }

        private void OpenBagPanel()
        {
            PanelManager.OpenPanel(PanelKey.Bag);
        }

        private void OpenLoadPanel(int sceneIndex)
        {
            if (PanelManager.PanelDic[PanelKey.Load] is LoadPanel loadPanel)
            {
                loadPanel.loadScreenIndex = sceneIndex;
            }

            PanelManager.OpenPanel(PanelKey.Load);
        }
    }
}