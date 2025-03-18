using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Action3rd
{
    public class LoadManager : MonoBehaviour
    {
        public GameObject loadScreen;
        public TMP_Text loadText;
        public Slider loadSlider;
        
        public void LoadNextLevel()
        {
            StartCoroutine(Loadlevel());
        }

        IEnumerator Loadlevel()
        {
            loadScreen.SetActive(true);
            AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            operation.allowSceneActivation = false;

            while(!operation.isDone)
            {
                loadSlider.value = operation.progress;
                loadText.text = operation.progress * 100 + "%";

                if(operation.progress >= 0.9f)
                {
                    loadSlider.value = 1;

                    loadText.text = "Press AnyKey To Continue";

                    if(Input.anyKeyDown)
                    {
                        operation.allowSceneActivation = true;
                    }
                }
                yield return null;
            }
        }
    }
}
