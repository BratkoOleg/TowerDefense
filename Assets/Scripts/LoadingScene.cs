using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    void Awake()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneName);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
