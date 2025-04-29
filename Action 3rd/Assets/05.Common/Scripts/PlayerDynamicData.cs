using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Unity.VisualScripting;

namespace Action3rd
{
    /// <summary>
    /// 数据类,玩家所有的动态数据
    /// </summary>
    public static class PlayerDynamicData
    {
        private static readonly string FilePath = Path.Combine(Application.persistentDataPath, "PackageItemDatas.json");

        private static Dictionary<StorableItemType, List<StorableItemData>> _packageItemDataDic;

        public static Dictionary<StorableItemType, List<StorableItemData>> PackageItemDataDic => _packageItemDataDic ??=
            Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<StorableItemType, List<StorableItemData>>>
            (
                LocalFileStreamIO.ReadStringFromFile(FilePath)
            ) ?? new Dictionary<StorableItemType, List<StorableItemData>>()
            {
                { StorableItemType.武器, new List<StorableItemData>() },
                { StorableItemType.食物, new List<StorableItemData>() }
            };

        public static void SavePackageItemData()
        {
            string jsonData =
                Newtonsoft.Json.JsonConvert.SerializeObject(PackageItemDataDic, Newtonsoft.Json.Formatting.Indented);
            LocalFileStreamIO.WriteStringToFile(FilePath, jsonData);
        }

        public static void UpdatePackageItemData(string itemId, StorableItemData item)
        {
        }

        /// <summary>
        /// 获得物品(可堆叠或不可堆叠)
        /// </summary>
        /// <param name="itemData">新物品</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ObtainItem(StorableItemData itemData)
        {
            switch (PlayerStaticData.StorableItemInfoConfig.ItemInfos[itemData.InfoIndex].type)
            {
                case StorableItemType.武器:
                    PackageItemDataDic[StorableItemType.武器].Add(itemData);
                    break;
                case StorableItemType.食物:
                    {
                        StorableItemData a = PackageItemDataDic[StorableItemType.食物]
                            .FirstOrDefault(v => v.InfoIndex == itemData.InfoIndex);

                        if (a != null)
                        {
                            a.Quantity += itemData.Quantity;
                        }
                        else
                        {
                            PackageItemDataDic[StorableItemType.食物].Add(itemData);
                        }

                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        //=================

        private static readonly string PlayerStateDateFilePath =
            Path.Combine(Application.persistentDataPath, "PlayerStateDate.json");

        private static PlayerStateDate _playerState;

        // public static PlayerStateDate PlayerStateDate => _playerStateDate ??=
        //     Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerStateDate>
        //     (
        //         LocalFileStreamIO.ReadStringFromFile(PlayerStateDateFilePath)
        //     ) ?? new PlayerStateDate();
        public static PlayerStateDate PlayerState
        {
            get
            {
                if (_playerState != null) { return _playerState; }

                if (File.Exists(PlayerStateDateFilePath))
                {
                    _playerState = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerStateDate>
                    (
                        LocalFileStreamIO.ReadStringFromFile(PlayerStateDateFilePath)
                    );
                }
                else
                {
                    _playerState = new PlayerStateDate();
                }

                return _playerState ??= new PlayerStateDate();
                // if (_playerState != null && _playerState.Weapon != null)
                // {
                //     _playerState.Weapon = PackageItemDataDic[StorableItemType.武器]
                //         .FirstOrDefault(x => x.ItmId == _playerState.Weapon.ItmId);
                // }
            }
            set => _playerState = value;
        }

        public static void SavePlayerStateDate()
        {
            string jsonData =
                Newtonsoft.Json.JsonConvert.SerializeObject(PlayerState, Newtonsoft.Json.Formatting.Indented);
            LocalFileStreamIO.WriteStringToFile(PlayerStateDateFilePath, jsonData);
        }
    }

    public class PlayerStateDate
    {
        public PlayerStateDate(StorableItemData weapon = null, int hp = 100)
        {
            this.weapon = weapon;
            this.Hp = hp;
        }

        private StorableItemData weapon;

        public StorableItemData Weapon
        {
            get => weapon;
            set
            {
                Debug.Log(value?.InfoIndex);
                weapon = value;
            }
        }

        public int Hp;
    }
}