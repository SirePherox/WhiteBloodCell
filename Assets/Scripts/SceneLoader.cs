using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonCreator<SceneLoader>
{
    [Header("Variables")]
    private float sceneLoadDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Meethod should be called with the StartCoroutine
    /// </summary>
    /// <param name="sceneIndex"></param>
    /// <returns></returns>
    public IEnumerator LoadSceneInAsync(int sceneIndex)
    {
        yield return new WaitForSeconds(sceneLoadDelay);

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncOp.isDone)
        {
            Debug.Log(asyncOp.progress);
            yield return null;
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex());
    }
}
