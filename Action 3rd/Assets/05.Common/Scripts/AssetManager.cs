using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Action3rd
{
    public class AssetManager : Singleton<AssetManager>
    {
        public Dictionary<IList<string>, AsyncOperationHandle> HandleDict { get; private set; } = new();

        public AsyncOperationHandle GetHandle<T>(IList<string> key)
        {
            if (!HandleDict.TryGetValue(key, out AsyncOperationHandle handle))
            {
                // HandleDict.Add(key, new AsyncOperationHandle());
                return Addressables.LoadAssetsAsync<T>(key, _ => { }, Addressables.MergeMode.Intersection);
            }
            else
            {
                return handle;
            }
        }

        // public static void CatalogUpdate()
        // {
        //     Addressables.CheckForCatalogUpdates().Completed += handle =>
        //     {
        //         if (handle.Result.Count > 0)
        //         {
        //             Debug.Log("有更新");
        //             Addressables.UpdateCatalogs().Completed += handleUpdate =>
        //             {
        //                 Debug.Log
        //                 (handleUpdate.Status ==
        //                  UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded
        //                     ? "目录更新完成"
        //                     : "目录更新失败"
        //                 );
        //                 Addressables.Release(handleUpdate);
        //             };
        //         }
        //         else
        //         {
        //             Debug.Log("没有更新");
        //         }
        //     };
        // }
    }
}