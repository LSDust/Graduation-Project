using System.Collections.Generic;

namespace Action3rd.UI
{
    public static class PanelManager
    {
        //处于激活状态Panel的栈
        private static Stack<BasePanel> Stack = new();

        //Panel字典
        public static Dictionary<PanelKey, BasePanel> PanelDic = new();

        public static BasePanel OpenPanel(PanelKey panelName)
        {
            if (Stack.Count > 0)
            {
                BasePanel topPanel = Stack.Peek();
                topPanel.OnPause();
            }

            PanelDic[panelName].gameObject.SetActive(true);
            PanelDic[panelName].OnEnter();
            Stack.Push(PanelDic[panelName]);
            return PanelDic[panelName];
        }

        public static void ClosePanel()
        {
            if (Stack.Count == 0)
            {
                return;
            }

            BasePanel closePanel = Stack.Pop();
            closePanel.OnExit();
            if (Stack.Count > 0)
            {
                BasePanel resumePanel = Stack.Peek();
                resumePanel.OnResume();
            }
        }
    }

    public enum PanelKey { Main, Setting, Bag, Load }
}