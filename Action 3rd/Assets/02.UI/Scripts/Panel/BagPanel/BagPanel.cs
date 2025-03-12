using UnityEngine;
using UnityEngine.UI;

namespace Action3rd.UI
{
    public class BagPanel : BasePanel
    {
        [SerializeField] private Button exitButton;

        private void Awake()
        {
            exitButton.onClick.AddListener(CloseBagPanel);
        }

        private void CloseBagPanel()
        {
            PanelManager.ClosePanel();
        }

        private void Start()
        {
        }
    }
}