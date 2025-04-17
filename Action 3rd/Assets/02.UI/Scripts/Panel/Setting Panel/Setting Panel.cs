using UnityEngine;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class SettingPanel : BasePanel
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private Button cancelButton;
        [SerializeField] private Slider globalVolumeSlider;
        [SerializeField] private Slider skillVolumeSlider;

        public override void OnEnter()
        {
            base.OnEnter();
            Time.timeScale = 0f;
        }

        public override void OnExit()
        {
            base.OnExit();
            Time.timeScale = 1f;
        }

        private void Awake()
        {
            saveButton.onClick.AddListener(SaveSetting);
            cancelButton.onClick.AddListener(CancelSetting);
        }

        private void Start()
        {
            globalVolumeSlider.value = PlayerPrefs.GetInt("GlobalVolume", DefaultSetting.GlobalVolume);
            skillVolumeSlider.value = PlayerPrefs.GetInt("SkillVolume", DefaultSetting.SkillVolume);
        }

        private void SaveSetting()
        {
            PlayerPrefs.SetInt("GlobalVolume", (int)globalVolumeSlider.value);
            PlayerPrefs.SetInt("SkillVolume", (int)skillVolumeSlider.value);
            PlayerPrefs.Save();
            PanelManager.ClosePanel();
        }

        private void CancelSetting()
        {
            PanelManager.ClosePanel();
        }
    }

    public static class DefaultSetting
    {
        public const int GlobalVolume = 5;
        public const int SkillVolume = 5;
    }
}