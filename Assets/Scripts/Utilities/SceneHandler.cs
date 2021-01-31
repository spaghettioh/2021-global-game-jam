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
    bool readyToPlay = false;

    private void Start()
    {
        scrim.gameObject.SetActive(true);
        StartCoroutine(ArtificialWait(false));
        Time.timeScale = 1;
    }

    public void LoadASceneAsync()
    {
        if (nextSceneName != "")
        {
            StartCoroutine(ArtificialWait(true));
            //SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);
            //return;
        }
        else
        {
            throw(new System.Exception("Looks like you forgot to provide a scene name"));
        }
    }

    IEnumerator ArtificialWait(bool loadNextLevel)
    {
        scrim.gameObject.SetActive(true);


        if (loadNextLevel)
        {
            progressBar.gameObject.SetActive(true);
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                scrim.color = new Color(0, 0, 0, i);
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            if (loadNextLevel)
            {
                StartCoroutine(LoadSceneAsynchronously());
            }
        }
        else
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                scrim.color = new Color(0, 0, 0, i);
                yield return null;
            }

        }


        //scrim.CrossFadeAlpha(1, 1, false);
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
