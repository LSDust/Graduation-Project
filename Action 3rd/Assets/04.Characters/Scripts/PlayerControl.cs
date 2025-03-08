using UnityEngine;

namespace Action3rd
{
    public class PlayerControl : Singleton<PlayerControl>
    {
        private Animator _animator;

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Vector3 dir =
                (Input.GetAxis("Horizontal") * Vector3.right) + (Input.GetAxis("Vertical") * Vector3.forward);
            _animator.SetFloat("Speed", dir.magnitude * 20f);

            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetTrigger("Attack");
            }
        }
    }
}