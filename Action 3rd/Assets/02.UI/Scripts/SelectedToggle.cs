using System;
using UnityEngine;
using UnityEngine.UI;

namespace Action3rd
{
    /// <summary>
    /// 必须同时挂在ToggleGroup上
    /// </summary>
    public class SelectedToggle : MonoBehaviour
    {
        private Action<Toggle> _onSelectedToggle;

        public event Action<Toggle> OnSelectedToggle
        {
            add => _onSelectedToggle += value;
            remove => _onSelectedToggle -= value;
        }

        private Toggle[] _toggles;

        void Start()
        {
            _toggles = transform.GetComponentsInChildren<Toggle>();
            for (int i = 0; i < _toggles.Length; i++)
            {
                Toggle toggle = _toggles[i];
                toggle.onValueChanged.AddListener((bool value) => OnToggleValueChanged(toggle));
            }
        }

        private void OnToggleValueChanged(Toggle toggle)
        {
            if (toggle.isOn)
            {
                _onSelectedToggle?.Invoke(toggle);
            }
        }
    }
}