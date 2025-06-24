using System;
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

        private AudioSource bgmAudioSource;

        private AudioSource BGMAudioSource
        {
            get
            {
                if (bgmAudioSource == null)
                {
                    bgmAudioSource =  Camera.main?.GetComponent<AudioSource>();
                }

                return bgmAudioSource;
            }
        }

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
            globalVolumeSlider.onValueChanged.AddListener(GlobalVolumeSliderValueChanged);
        }

        private void GlobalVolumeSliderValueChanged(float arg0)
        {
            this.BGMAudioSource.volume = arg0 / 100f;
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
            globalVolumeSlider.value = PlayerPrefs.GetInt("GlobalVolume", DefaultSetting.GlobalVolume);
            skillVolumeSlider.value = PlayerPrefs.GetInt("SkillVolume", DefaultSetting.SkillVolume);
            PanelManager.ClosePanel();
        }
    }
}