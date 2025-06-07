using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Action3rd
{
    public class TestMono : MonoBehaviour
    {
        public event Action UpdateAssetsEnd;
        public AssetReferenceGameObject obj;
        public Dictionary<int, int> A;

        // public event Action<GameObject> Action1;
        public Dictionary<List<string>, Object> PrefabDict = new();

        private void Awake()
        {
            Debug.Log(23232323);
        }

        // Start is called before the first frame update
        void Start()
        {
            // CatalogUpdate();
            // StartCoroutine(CheckDownLoadSize(new List<string>() { "prefab" }));
            // StartCoroutine(UpdateAssets(new List<string>() { "prefab" }));
        }

        // private void CatalogUpdate()
        // {
        //     Addressables.CheckForCatalogUpdates().Completed += handle =>
        //     {
        //         if (handle.Result.Count > 0)
        //         {
        //             Debug.Log("有更新");
        //             Addressables.UpdateCatalogs().Completed += _ =>
        //             {
        //                 if (handle.Status ==
        //                     UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
        //                 {
        //                     Debug.Log("目录更新完成");
        //                 }
        //                 else
        //                 {
        //                     Debug.Log("目录更新失败");
        //                 }
        //             };
        //         }
        //         else
        //         {
        //             Debug.Log("没有更新");
        //         }
        //
        //         // Addressables.Release(handle);
        //     };
        // }

        // Update is called once per frame
        public GameObject handleR;
        AsyncOperationHandle<GameObject> handle1;

        void Update()
        {
            //AssetReferenceGameObject
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                // StartCoroutine(Load());
                handle1 = obj.LoadAssetAsync();
                handle1.Completed += h => { };
            }

            if (Keyboard.current.wKey.wasPressedThisFrame)
            {
                if (handle1.IsDone)
                {
                    Instantiate(handle1.Result);
                }
            }

            // Addressables.Release(newObj);

            // List<string> keys = new List<string>() { "prefab", "cube" };
            // if (Keyboard.current.wKey.wasPressedThisFrame)
            // {
            //     Object obj1;
            //     if (this.PrefabDict.ContainsKey(keys))
            //     {
            //         obj1 = PrefabDict[keys];
            //     }
            //     else
            //     {
            //         obj1 = Addressables.LoadAssetsAsync<GameObject>(keys, Action1, Addressables.MergeMode.Intersection)
            //             .Result[0];
            //         this.PrefabDict.Add(keys, obj1);
            //     }
            //
            //     Addressables.Release(PrefabDict[keys]);
            // }
            //
            // if (Keyboard.current.qKey.wasPressedThisFrame)
            // {
            //     Addressables.LoadResourceLocationsAsync(keys, typeof(Object)).Completed += handle =>
            //     {
            //         foreach (var item in handle.Result)
            //         {
            //         }
            //     };
            // }
            //
            // if (Keyboard.current.eKey.wasPressedThisFrame)
            // {
            //     Addressables.LoadSceneAsync("DungeonScene", LoadSceneMode.Additive).Completed += handle =>
            //     {
            //     };
            // }

            // if (Input.GetKeyDown(KeyCode.Q))
            // {
            //     //动态加载单个资源
            //     var a = Addressables.LoadAssetAsync<GameObject>("Cube").Result;
            // }
            //
            // if (Input.GetKeyDown(KeyCode.W))
            // {
            //     //动态加载多个资源
            //     Addressables.LoadAssetsAsync<GameObject>("prefab", objs =>
            //     {
            //         Instantiate(objs);
            //     }).Completed += handle =>
            //     {
            //         foreach (var item in handle.Result)
            //         {
            //             Debug.Log(item.name);
            //         }
            //     };
            // }
        }

        IEnumerator Load()
        {
            var handle = obj.LoadAssetAsync();
            yield return handle;
            GameObject newObj = Instantiate(handle.Result);
            newObj.transform.position = Vector3.zero;
        }

        IEnumerator CheckDownLoadSize(IList<string> keys)
        {
            AsyncOperationHandle<long> handle = Addressables.GetDownloadSizeAsync(keys);
            yield return handle;
            if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                if (handle.Result <= 0)
                {
                    Debug.Log("资源没更新");
                }
                else
                {
                    Debug.Log($"资源有更新{handle.Result.ToString()}");
                }
            }
            // Addressables.Release(handle);
        }

        public IEnumerator UpdateAssets(IList<string> keys)
        {
            AsyncOperationHandle handle = Addressables.DownloadDependenciesAsync(keys, Addressables.MergeMode.Union);
            long size = handle.GetDownloadStatus().TotalBytes;
            Debug.Log($"开始下载资源{size}");
            while (!handle.IsDone)
            {
                long downloadedSize = handle.GetDownloadStatus().DownloadedBytes;
                float percent = handle.GetDownloadStatus().Percent;
                Debug.Log($"已下载：{downloadedSize}--{percent}");
                yield return null;
            }

            if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                Debug.Log("资源下载完成");
                UpdateAssetsEnd?.Invoke();
            }

            Addressables.Release(handle);
        }
    }
}