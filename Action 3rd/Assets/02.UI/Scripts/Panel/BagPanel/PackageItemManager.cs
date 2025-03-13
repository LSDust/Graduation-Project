using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Action3rd
{
    public class PackageItemManager : MonoBehaviour
    {
        [SerializeField] public GameObject packageItemPrefab;
    }

    public class PackageItemData
    {
        public int Id;
        public PackageItemType PackageItemType;
        public Sprite Icon;
        public string Name;
        public string Description;

        //动态数据
        public string Uid;
        public int Level;
    }

    public enum PackageItemType { 武器, 食物 }
}