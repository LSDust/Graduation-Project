using UnityEngine;

namespace Action3rd.UI
{
    public class BasePanel : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        /// <summary>
        /// 当打开Panel的时候调用OnEnter方法
        /// </summary>
        public virtual void OnEnter() 
        {
            if (_canvasGroup == null)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
            }
    
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    
    
        /// <summary>
        /// Panel显示,但是不能交互
        /// </summary>
        public virtual void OnPause() 
        {
            //canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    
    
        /// <summary>
        /// Panel恢复交互的状态
        /// </summary>
        public virtual void OnResume() 
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    
        /// <summary>
        /// 当关闭Panel的时候调用OnExit方法
        /// </summary>
        public virtual void OnExit() 
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}