using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Action3rd.UI
{
    /// <summary>
    /// 大管理类,挂在画布上
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        protected void Awake()
        {
            // base.Awake();
            DontDestroyOnLoad(this.gameObject);
            if (!PanelManager.PanelDic.ContainsKey(PanelKey.Main))
            {
                PanelManager.PanelDic.Add(PanelKey.Main, transform.Find("Main Panel").GetComponent<MainPanel>());
            }

            if (!PanelManager.PanelDic.ContainsKey(PanelKey.Setting))
            {
                SettingPanel settingPanel = transform.Find("Setting Panel").GetComponent<SettingPanel>();
                PanelManager.PanelDic.Add(PanelKey.Setting, settingPanel);
            }

            if (!PanelManager.PanelDic.ContainsKey(PanelKey.Bag))
            {
                PanelManager.PanelDic.Add(PanelKey.Bag, transform.Find("Bag Panel").GetComponent<BagPanel>());
            }

            if (!PanelManager.PanelDic.ContainsKey(PanelKey.Load))
            {
                PanelManager.PanelDic.Add(PanelKey.Load, transform.Find("Load Panel").GetComponent<LoadPanel>());
            }
        }

        private void Start()
        {
            PanelManager.OpenPanel(PanelKey.Main);
        }
    }
}