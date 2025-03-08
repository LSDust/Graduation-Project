using UnityEngine;

namespace Action3rd
{
    public class DrawSwordEvent : MonoBehaviour
    {
        [SerializeField] private Transform swordBody;

        /// <summary>
        ///     持剑手
        /// </summary>
        [SerializeField] private Transform swordHead;

        private void DrawSword()
        {
            swordBody.SetParent(swordHead, true);
        }
    }
}