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
            }
        }
    }
}