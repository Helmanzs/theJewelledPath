using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : GameSingleton<SceneLoader>
{
    public GameObject loadingScreen;
    public CanvasGroup canvasGroup;

    public void LoadScene(string sceneToLoad)
    {
        StartCoroutine(StartLoad(sceneToLoad));
    }
    IEnumerator StartLoad(string sceneToLoad)
    {
        loadingScreen.SetActive(true);
        yield return StartCoroutine(FadeLoadingScreen(1, 1));
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!operation.isDone)
        {
            yield return null;
        }
        yield return StartCoroutine(FadeLoadingScreen(0, 1));
        loadingScreen.SetActive(false);
    }
    IEnumerator FadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.fixedDeltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }
}