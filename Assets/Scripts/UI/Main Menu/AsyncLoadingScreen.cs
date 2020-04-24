using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AsyncLoadingScreen : MonoBehaviour
{
    [Header("Загружаемая сцена")]
    public static int sceneID;
    
    public Text progressText;
    private void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress/0.9f;
            progressText.text = " Loading: " + string.Format("{0:0}%", progress * 100);
            yield return null;
        }
    }
}
