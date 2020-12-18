using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineControl : MonoBehaviour
{
    [Header("場景切換")]
    public string movie1;
    public string movie2;
    private void OnEnable()
    {
        StartCoroutine(LoadScene(movie2));
    }

    IEnumerator LoadScene(string ns)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(ns, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
