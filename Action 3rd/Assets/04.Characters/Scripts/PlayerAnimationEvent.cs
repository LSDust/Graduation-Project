using System;
using UnityEngine;

namespace Action3rd
{
    public class PlayerAnimationEvent : MonoBehaviour
    {
        public GameObject backSword;
        public GameObject holdingSword;
        [Header("特效文件")] [SerializeField] private GameObject a1VFX;
        [SerializeField] private GameObject a2VFX;
        [SerializeField] private GameObject a3VFX;
        [SerializeField] private GameObject a4VFX;

        [Header("特效位置")] [SerializeField] private Transform a1VFXPosition;
        [SerializeField] private Transform a2VFXPosition;
        [SerializeField] private Transform a3VFXPosition;
        [SerializeField] private Transform a4VFXPosition;

        private Collider[] results = { };

        private void DrawSword()
        {
            backSword.SetActive(false);
            holdingSword.SetActive(true);
        }

        private void Retract()
        {
            backSword.SetActive(true);
            holdingSword.SetActive(false);
        }

        private void A1Event()
        {
            GameObject.Instantiate(a1VFX,
                this.a1VFXPosition.position,
                Quaternion.Euler(new Vector3(0, 0, 0) + this.transform.eulerAngles));

            this.results = Physics.OverlapSphere(this.a1VFXPosition.position, 5f);
            foreach (Collider t in results)
            {
                if (t.gameObject.CompareTag("Monster"))
                {
                    t.GetComponent<WithHp>().UnderAttack(20);
                }
            }

            Loss();
        }

        private void A2Event()
        {
            GameObject.Instantiate(a2VFX,
                this.a2VFXPosition.position,
                Quaternion.Euler(new Vector3(0, 0, 0) + this.transform.eulerAngles));
            this.results = Physics.OverlapCapsule(this.a2VFXPosition.position,
                transform.forward.normalized * 5 + this.a2VFXPosition.position, 2f);
            foreach (Collider t in results)
            {
                if (t.gameObject.CompareTag("Monster"))
                {
                    t.GetComponent<WithHp>().UnderAttack(25);
                }
            }
        }

        private void A3Event()
        {
            GameObject.Instantiate(a3VFX,
                this.a3VFXPosition.position,
                Quaternion.Euler(new Vector3(0, 0, 0) + this.transform.eulerAngles));
            this.results = Physics.OverlapSphere(this.a1VFXPosition.position, 5f);
            foreach (Collider t in results)
            {
                if (t.gameObject.CompareTag("Monster"))
                {
                    t.GetComponent<WithHp>().UnderAttack(25);
                }
            }
        }

        private void A4Event()
        {
            GameObject.Instantiate(a4VFX,
                this.a4VFXPosition.position,
                Quaternion.Euler(new Vector3(0, -90, 0) + this.transform.eulerAngles));
            this.results = Physics.OverlapSphere(this.a1VFXPosition.position, 5f);
            foreach (Collider t in results)
            {
                if (t.gameObject.CompareTag("Monster"))
                {
                    t.GetComponent<WithHp>().UnderAttack(30);
                }
            }
        }

        private static void Loss()
        {
            if (PlayerDynamicData.PlayerStateDate.Weapon.Durability > 1)
            {
                PlayerDynamicData.PlayerStateDate.Weapon.Durability--;
            }
            else
            {
                Debug.Log("要销毁");
            }
        }

        private void OnApplicationQuit()
        {
            PlayerDynamicData.SavePlayerStateDate();
        }
    }
}