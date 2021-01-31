using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeveLoader : MonoBehaviour
{
    public Slider loadingProgressBar;
    public Text loadingProgressLabel;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsynchronously(sceneIndex));
    }

    IEnumerator LoadSceneAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingProgressBar.value = progress;
            loadingProgressLabel.text = progress * 100 + "%";

            yield return null;
        }
    }
}
