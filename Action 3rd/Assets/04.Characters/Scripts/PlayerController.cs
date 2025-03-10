using UnityEngine;
using UnityEngine.InputSystem;

namespace Action3rd
{
    public class PlayerController : Singleton<PlayerController>
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private Animator _animator;

        /// <summary>
        ///     移动方向
        /// </summary>
        private Vector2 _playerInputVec;

        private Rigidbody _rigidbody;


        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            InputManager.Instance.InputAssetObject.Player.Move.performed += GetPlayerMoveInput;
            InputManager.Instance.InputAssetObject.Player.Move.canceled += GetPlayerMoveInput;
            InputManager.Instance.InputAssetObject.Player.Jump.started += GetPlayerJumpInput;
            InputManager.Instance.InputAssetObject.Player.Fire.started += _ => _animator.SetTrigger(Attack);
        }

        private void Update()
        {
            if (_playerInputVec != Vector2.zero)
            {
                //todo:拔剑和攻击时不允许旋转
                transform.rotation = Quaternion.LookRotation(new Vector3(_playerInputVec.x, 0, _playerInputVec.y));
            }
        }

        private void GetPlayerMoveInput(InputAction.CallbackContext ctx)
        {
            _playerInputVec = ctx.ReadValue<Vector2>();

            //todo:不会渐变
            _animator.SetFloat(Speed, _playerInputVec.magnitude);
        }

        private void GetPlayerJumpInput(InputAction.CallbackContext ctx)
        {
            _rigidbody.velocity += Vector3.up * 5f;
        }

        public void GetPlayerLookInput(InputAction.CallbackContext ctx)
        {
            // Debug.Log(ctx.phase.ToString());
        }
    }
}