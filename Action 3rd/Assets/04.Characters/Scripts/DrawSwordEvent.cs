using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Action3rd
{
    public class DrawSwordEvent : MonoBehaviour
    {
        /// <summary>
        /// 剑鞘
        /// </summary>
        [SerializeField] private Transform scabbard;
        [SerializeField] private Transform swordBody;
        /// <summary>
        /// 持剑手
        /// </summary>
        [SerializeField] private Transform swordHead;
        
        private void DrawSword()
        {
            this.swordBody.SetParent(this.swordHead,true);
        }
    }
}