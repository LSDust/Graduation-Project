using UnityEditor.Build.Pipeline;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Action3rd
{
    public class PlayerController : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Sprint = Animator.StringToHash("Sprint");
        private static readonly int Skill1 = Animator.StringToHash("Skill1");
        private Animator _animator;
        private CharacterController _characterController;

        Vector3 playerMovement;
        Transform playerTramsform;

        public float rotateSpeed = 1000;//旋转速度

        public float gravity = -9.8f;//重力

        private Vector3 g_Velocity = Vector3.zero;//重力速度

        public Transform groundCheck;//检测地面的位置
        public float groundRadius = 0.2f;//检测地面的半径
        private bool isGrounded;//是否在地面上
        private Vector2 _playerInputVec;//玩家输入的方向

        public float jumpHeight = 3f;//跳跃高度

        //private bool isRunning;
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
            InputManager.Instance.InputAssetObject.Player.Skill1.performed += _ => _animator.SetTrigger(Skill1);
            InputManager.Instance.InputAssetObject.Player.Sprint.performed += GetPlayerSprintInput;
        }

        private void Update()
        {
            _playerInputVec = InputManager.Instance.InputAssetObject.Player.Move.ReadValue<Vector2>();
            _animator.SetFloat(Speed, _playerInputVec.magnitude, 0.1f, Time.deltaTime);
            RotatePlayer();
            //CancelRunning();
        }

        private void OnAnimatorMove()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, LayerMask.GetMask("Ground"));
            if (isGrounded && g_Velocity.y < 0)
            {
                g_Velocity.y = 0;
            }

            Vector3 moveSpeed = _animator.velocity;
            g_Velocity.y += gravity * Time.deltaTime;
            _characterController.Move((moveSpeed + g_Velocity) * Time.deltaTime);

            //if (isRunning)
            //{
            //    _characterController.SimpleMove(moveSpeed);
            //}
        }

        private void GetPlayerJumpInput(InputAction.CallbackContext ctx)
        {
            if (isGrounded)
            {
                _animator.SetTrigger(Jump);

                //g_Velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        private void GetPlayerSprintInput(InputAction.CallbackContext ctx)
        {
            _animator.SetTrigger(Sprint);
            // 瞬时位移
            Vector3 forward = playerTramsform.forward;
            Vector3 moveSpeed = _animator.velocity * 2;
            _characterController.Move((moveSpeed + g_Velocity) * Time.deltaTime);
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