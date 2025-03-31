using System;
using UnityEngine;

namespace Action3rd
{
    public class WithHp : MonoBehaviour
    {
        [SerializeField] private int hp = 100;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PlayerSkill"))
            {
                hp -= 50;
            }

            if (hp <= 0)
            {
                Destroy(gameObject);
                PlayerDynamicData.ObtainItem(new StorableItemData(PlayerStaticData.GetRandomKey(),
                    Guid.NewGuid().ToString()));
                PlayerDynamicData.SavePackageItemData();
            }
        }

        public void UnderAttack(int damage)
        {
            this.hp -= damage;
            if (this.hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}