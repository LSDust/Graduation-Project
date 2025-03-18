using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.VirtualTexturing;

namespace Action3rd
{
    public class AssetLoadTest : MonoBehaviour
    {
        private GameObject _cubePrefab;

        // Start is called before the first frame update
        void Start()
        {
        }

        void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                // var handle =
                //     AssetManager.Instance.GetHandle<GameObject>(new List<string> { "prefab", "character", "cube" });
                // Debug.Log(AssetManager.Instance.HandleDict.Count);
                // GameObject.Instantiate(_cubePrefab);
                // var handle = 
                //     AssetManager.Instance.GetHandle<GameObject>(new List<string> { "prefab", "character", "cube" });
                // List<GameObject> objs = handle.Result as List<GameObject>;
                // Debug.Log(objs.Count);
            }
        }
    }
}