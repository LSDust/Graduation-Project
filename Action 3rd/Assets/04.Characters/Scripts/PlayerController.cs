using UnityEngine;

namespace Action3rd
{
    public class PlayerController : Singleton<PlayerController>
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        // private static readonly int Speed = Animator.StringToHash("Speed");
        private Animator _animator;
        private Rigidbody _rigidbody;

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            // Vector3 direction = (Input.GetAxis("Horizontal") * Vector3.right) +
            //                     (Input.GetAxis("Vertical") * Vector3.forward);
            // transform.rotation = Quaternion.LookRotation(direction);
            // _animator.SetFloat(Speed, direction.magnitude);

            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetTrigger(Attack);
            }
        }
    }
}