using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Action3rd.UI
{
    public class LoadPanel : BasePanel
    {
        // public GameObject loadScreen;
        public TMP_Text loadText;
        public Slider loadSlider;

        public int loadScreenIndex;

        // public void LoadNextLevel()
        // {
        //     StartCoroutine(Loadlevel(1));
        // }

        public override void OnEnter()
        {
            base.OnEnter();
            StartCoroutine(LoadLevel(loadScreenIndex));
        }

        private IEnumerator LoadLevel(int sceneIndex = -1)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                loadSlider.value = operation.progress;
                loadText.text = operation.progress * 100 + "%";

                if (operation.progress >= 0.9f)
                {
                    loadSlider.value = 1;

                    loadText.text = "Press AnyKey To Continue";

                    if (Mouse.current.rightButton.wasPressedThisFrame)
                    {
                        operation.allowSceneActivation = true;
                        PanelManager.ClosePanel();
                    }
                }

                yield return null;
            }
        }
    }
}