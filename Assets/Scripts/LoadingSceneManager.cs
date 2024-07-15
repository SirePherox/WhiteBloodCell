using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingSceneManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private float loadingSceneDelay = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartCoroutine( LoadNextScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private System.Collections.IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(loadingSceneDelay);

        StartCoroutine(SceneLoader.Instance.LoadSceneInAsync(
            PlayerPrefsManager.Instance.GetNextSceneToLoad()));
    }
}
