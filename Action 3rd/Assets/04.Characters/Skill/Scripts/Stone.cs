using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Action3rd
{
    public class Stone : MonoBehaviour
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
                Debug.Log("攻击到了玩家");
                other.GetComponent<WithHp>().UnderAttack(10);
                Destroy(this.gameObject);
            }
            if (other.CompareTag("Ground"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}