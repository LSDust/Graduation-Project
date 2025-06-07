using System;
using UnityEngine;

namespace Action3rd
{
    public class WithHp : MonoBehaviour
    {
        public int hp = 100;
        public event Action OnDeath;


        public void UnderAttack(int damage)
        {
            this.hp -= damage;
            if (this.hp <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}