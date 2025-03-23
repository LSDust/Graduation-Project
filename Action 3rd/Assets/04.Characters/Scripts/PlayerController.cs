using UnityEditor.Build.Pipeline;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Action3rd
{
    public class PlayerController : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private Animator _animator;
        private CharacterController _characterController;

        Vector3 playerMovement;
        Transform playerTramsform;

        public float rotateSpeed = 1000;
        /// <summary>
        ///     移动方向
        /// </summary>
        private Vector2 _playerInputVec;


        protected void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            playerTramsform = transform;
            Cursor.lockState = CursorLockMode.Locked;
            InputManager.Instance.InputAssetObject.Player.Jump.performed += GetPlayerJumpInput;
            InputManager.Instance.InputAssetObject.Player.Fire.performed += _ => _animator.SetTrigger(Attack);
        }

        private void Update()
        {
            _playerInputVec = InputManager.Instance.InputAssetObject.Player.Move.ReadValue<Vector2>();
            _animator.SetFloat(Speed, _playerInputVec.magnitude, 0.1f, Time.deltaTime);
            RotatePlayer();
        }

        private void OnAnimatorMove()
        {
            Vector3 moveSpeed = _animator.velocity;
            _characterController.SimpleMove(moveSpeed);
        }

        private void GetPlayerJumpInput(InputAction.CallbackContext ctx)
        {
            // _rigidbody.velocity += Vector3.up * 5f;
        }

        static Vector3 幅角相加(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x - a.z * b.z, 0, a.x * b.z + a.z * b.x);
        }

        void RotatePlayer()
        {
            if (_playerInputVec != Vector2.zero)
            {
                //todo: 拔剑和攻击时不允许旋转
                Vector3 a = new Vector3(_playerInputVec.x, 0, _playerInputVec.y);
                Vector3 b = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
                Vector3 c = 幅角相加(幅角相加(a, b), Vector3.back);
                //transform.rotation = Quaternion.LookRotation(c);
                Quaternion targetRotataion = Quaternion.LookRotation(c);
                playerTramsform.rotation = Quaternion.RotateTowards(playerTramsform.rotation, targetRotataion, rotateSpeed * Time.deltaTime);
            }
        }
    }
}