using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Action3rd
{
    public class BGMController : MonoBehaviour
    {
        private AudioSource bgmAudioSource;

        private void Awake()
        {
            bgmAudioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            bgmAudioSource.volume = PlayerPrefs.GetInt("GlobalVolume", DefaultSetting.GlobalVolume) / 100f;
        }
    }
    
    public static class DefaultSetting
    {
        public const int GlobalVolume = 50;
        public const int SkillVolume = 50;
    }
}
