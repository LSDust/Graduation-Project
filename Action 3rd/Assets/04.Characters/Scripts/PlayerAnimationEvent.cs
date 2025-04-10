using UnityEngine;

namespace Action3rd
{
    public class PlayerAnimationEvent : MonoBehaviour
    {
        [SerializeField] private GameObject backSword;

        /// <summary>
        ///     持剑手
        /// </summary>
        [SerializeField] private GameObject holdingSword;

        private void DrawSword()
        {
            // swordBody.SetParent(swordHead, true);
            backSword.SetActive(false);
            holdingSword.SetActive(true);
        }

        private void Retract()
        {
            backSword.SetActive(true);
            holdingSword.SetActive(false);
        }
    }
}