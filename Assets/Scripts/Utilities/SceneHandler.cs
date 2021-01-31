using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneHandler : MonoBehaviour
{
    public string thisSceneName;
    public string nextSceneName;
    public Slider progressBar;
    public TMP_Text loadingProgressText;
    public Image scrim;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void LoadASceneAsync()
    {
        if (nextSceneName != "")
        {
            StartCoroutine(ArtificialWait());
            //SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);
            //return;
        }
        else
        {
            throw(new System.Exception("Looks like you forgot to provide a scene name"));
        }
    }

    IEnumerator ArtificialWait()
    {
        scrim.gameObject.SetActive(true);
        progressBar.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(LoadSceneAsynchronously());
    }

    IEnumerator LoadSceneAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            progressBar.value = progress;
            loadingProgressText.text = "LOADING..." + progress * 100 + "%";

            yield return null;
        }


    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
