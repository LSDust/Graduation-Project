using UnityEngine;

public class BasePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    /// <summary>
    /// 当打开Panel的时候调用OnEnter方法
    /// </summary>
    public virtual void OnEnter() 
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }


    /// <summary>
    /// Panel显示,但是不能交互
    /// </summary>
    public virtual void OnPause() 
    {
        //canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }


    /// <summary>
    /// Panel恢复交互的状态
    /// </summary>
    public virtual void OnResume() 
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// 当关闭Panel的时候调用OnExit方法
    /// </summary>
    public virtual void OnExit() 
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}