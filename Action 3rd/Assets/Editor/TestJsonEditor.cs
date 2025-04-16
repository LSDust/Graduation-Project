using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Action3rd
{
    [CustomEditor(typeof(TestJson))]
    public class TestJsonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            //获取附加的类
            TestJson t = (TestJson)target;
            //绘制Button
            if (GUILayout.Button("将Json覆盖到SO文件"))
            {
                // 执行方法
                t.configFile.ItemInfos =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, StorableItemInfo>>(
                        t.jsonStr);
            }
        }
    }
}