using UnityEngine;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class MainPanel : BasePanel
    {
        [SerializeField] private Button bagButton;

        [SerializeField] private Button settingButton;

        private void Awake()
        {
            settingButton.onClick.AddListener(OpenSettingPanel);
            bagButton.onClick.AddListener(OpenBagPanel);
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