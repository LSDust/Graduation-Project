using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Action3rd
{
    public class Booty : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(this.gameObject);
                PlayerDynamicData.ObtainItem(new StorableItemData(PlayerStaticData.GetRandomKey(),
                    Guid.NewGuid().ToString()));
                PlayerDynamicData.SavePackageItemData();
            }
        }
    }
}