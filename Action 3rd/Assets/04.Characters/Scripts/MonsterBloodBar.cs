using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Action3rd
{
    public class MonsterBloodBar : MonoBehaviour
    {
        private Canvas canvas;
        private Slider bloodBar;
        private WithHp hp;

        private void Awake()
        {
            this.canvas = this.GetComponent<Canvas>();
            canvas.worldCamera = Camera.main;
            this.bloodBar = this.GetComponentInChildren<Slider>();
            this.hp = this.GetComponentInParent<WithHp>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                Camera.main.transform.rotation * Vector3.up);
            this.bloodBar.value = this.hp.hp / 100f;
        }
    }
}