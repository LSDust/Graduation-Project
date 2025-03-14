using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class PackageItem : MonoBehaviour
    {
        public Image iconImage;
        public PackageItemData PackageItemData;
        public TMP_Text levelText;
    }

    public class PackageItemData
    {
        public int ItemInfoIndex;

        //动态数据
        public string Uid;
        public int Level;
        public bool IsNew;

        public PackageItemData(int itemInfoIndex, string uid, int level)
        {
            ItemInfoIndex = itemInfoIndex;
            Uid = uid;
            Level = level;
        }
    }
}