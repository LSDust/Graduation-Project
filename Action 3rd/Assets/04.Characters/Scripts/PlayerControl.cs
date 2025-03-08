using UnityEngine;

namespace Action3rd
{
    public class PlayerControl : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            Vector3 dir =
                ((Input.GetAxis("Horizontal") * Vector3.right) + (Input.GetAxis("Vertical") * Vector3.forward))
                .normalized;
            _animator.SetFloat("Speed", dir.magnitude * 20f);
            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetTrigger("Attack");
            }
        }
    }
}