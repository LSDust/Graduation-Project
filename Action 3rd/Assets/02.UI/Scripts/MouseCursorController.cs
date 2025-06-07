using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class MouseCursorController : MonoBehaviour
{
    public CanvasGroup hideUI;

    private bool wasCursorVisible = false;
    private bool uiForcesCursor = false;

    void Start()
    {
        SetCursorState(false);
    }

    void Update()
    {
        // 检查UI状态
        bool uiActive = !hideUI || !(hideUI.interactable && hideUI.blocksRaycasts && hideUI.alpha > 0);

        if (uiActive != uiForcesCursor)
        {
            uiForcesCursor = uiActive;
            if (uiForcesCursor)
            {
                wasCursorVisible = true;
                SetCursorState(true);
            }
            else if (!Keyboard.current.leftAltKey.isPressed)
            {
                SetCursorState(false);
            }
        }

        // 只在没有UI强制显示时处理Alt键
        if (!uiForcesCursor)
        {
            if (Keyboard.current.leftAltKey.wasPressedThisFrame)
            {
                wasCursorVisible = Cursor.visible;
                SetCursorState(true);
            }
            else if (Keyboard.current.leftAltKey.wasReleasedThisFrame)
            {
                if (!wasCursorVisible)
                {
                    SetCursorState(false);
                }
            }
        }
    }

    void SetCursorState(bool visible)
    {
        Cursor.visible = visible;
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}