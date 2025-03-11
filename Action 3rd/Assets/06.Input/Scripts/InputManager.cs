using UnityEngine;

namespace Action3rd
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager _instance;

        public Action3rdInput InputAssetObject;

        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject gameObject = new(nameof(InputManager));
                    _instance = gameObject.AddComponent<InputManager>();
                    DontDestroyOnLoad(gameObject);
                }

                return _instance;
            }
        }

        private void Awake()
        {
            InputAssetObject = new Action3rdInput();
        }

        private void OnEnable()
        {
            InputAssetObject.Enable();
        }

        private void OnDisable()
        {
            InputAssetObject.Disable();
        }
    }
}