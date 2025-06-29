using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Action3rd
{
    public class PlayerController : MonoBehaviour
    {
        // public static PlayerController Instance { get; private set; }

        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Roll = Animator.StringToHash("Roll");
        private static readonly int Skill1 = Animator.StringToHash("Skill1");
        private static readonly int Run = Animator.StringToHash("IsRun");
        private Animator _animator;
        private CharacterController _characterController;

        Vector3 playerMovement;
        Transform playerTramsform;

        public float rotateSpeed = 1000; //旋转速度

        public float gravity = -9.8f; //重力

        private Vector3 g_Velocity = Vector3.zero; //重力速度
        private Vector2 _playerInputVec; //玩家输入的方向

        public float jumpHeight = 3f; //跳跃高度

        private float shiftPressTime = 0.5f; // Shift键按压时间判定
        private Coroutine shiftCoroutine;

        protected void Awake()
        {
            // if (Instance != null && Instance != this)
            // {
            //     Destroy(gameObject);
            //     return;
            // }
            // Instance = this;
            //检查是否已有实例存在，如果存在则销毁当前对象，否则将当前对象设置为实例并调用 DontDestroyOnLoad 保持单例在场景切换时不被销毁。

            // DontDestroyOnLoad(gameObject);
            // DontDestroyOnLoad(Camera.main);
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            InputManager.Instance.InputAssetObject.Player.Jump.performed += GetPlayerJumpInput;
            InputManager.Instance.InputAssetObject.Player.Fire.performed += GetPlayerFireInput;
            InputManager.Instance.InputAssetObject.Player.Roll.performed += GetPlayerRollInput;
        }

        private void OnDisable()
        {
            InputManager.Instance.InputAssetObject.Player.Jump.performed -= GetPlayerJumpInput;
            InputManager.Instance.InputAssetObject.Player.Fire.performed -= GetPlayerFireInput;
            InputManager.Instance.InputAssetObject.Player.Roll.performed -= GetPlayerRollInput;
        }

        private void Start()
        {
            playerTramsform = transform;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            _playerInputVec = InputManager.Instance.InputAssetObject.Player.Move.ReadValue<Vector2>();
            _animator.SetFloat(Speed, _playerInputVec.magnitude, 0.1f, Time.deltaTime);
            RotatePlayer();

            if (!Keyboard.current.shiftKey.isPressed)
            {
                _animator.SetBool(Run, false);
            }
        }

        private void OnAnimatorMove()
        {
            if (_characterController.isGrounded && g_Velocity.y < 0)
            {
                g_Velocity.y = 0;
            }
            g_Velocity.y += gravity * Time.deltaTime;
            Vector3 moveSpeed = _animator.velocity;
            _characterController.Move((moveSpeed + g_Velocity) * Time.deltaTime);
        }

        private void GetPlayerFireInput(InputAction.CallbackContext ctx)
        {
            _animator.SetTrigger(Attack);
        }

        private void GetPlayerJumpInput(InputAction.CallbackContext ctx)
        {
            if (_characterController.isGrounded)
            {
                _animator.SetTrigger(Jump);
            }
        }

        private void GetPlayerRollInput(InputAction.CallbackContext ctx)
        {
            if (shiftCoroutine != null)
            {
                StopCoroutine(shiftCoroutine);
            }

            shiftCoroutine = StartCoroutine(HandleShiftPress());
        }

        private IEnumerator HandleShiftPress()
        {
            float pressTime = 0f;
            while (Keyboard.current.shiftKey.isPressed)
            {
                pressTime += Time.deltaTime;
                if (pressTime >= shiftPressTime)
                {
                    _animator.SetBool(Run, true);
                    yield break;
                }

                yield return null;
            }

            _animator.SetTrigger(Roll);
        }

        static Vector3 幅角相加(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x - a.z * b.z, 0, a.x * b.z + a.z * b.x);
        }

        void RotatePlayer()
        {
            if (_playerInputVec != Vector2.zero)
            {
                Vector3 a = new Vector3(_playerInputVec.x, 0, _playerInputVec.y);
                Vector3 b = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
                Vector3 c = 幅角相加(幅角相加(a, b), Vector3.back);
                Quaternion targetRotataion = Quaternion.LookRotation(c);
                playerTramsform.rotation = Quaternion.RotateTowards(playerTramsform.rotation, targetRotataion,
                    rotateSpeed * Time.deltaTime);
            }
        }
    }
}