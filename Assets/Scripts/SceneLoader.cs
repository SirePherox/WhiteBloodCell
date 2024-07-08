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

    /// <summary>
    /// loads a scene, but first shows
    /// the Loading scene
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void LoadSceneWithLoadingScene(int sceneIndex)
    {
        //save scene to load to playerprefs
        PlayerPrefsManager.Instance.SetNextSceneToLoad(sceneIndex);
        //load Loading scene
        LoadScene(SceneIndex.loadingScene);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(GetCurrentSceneIndex());
    }

    public int GetNextLevelSceneIndex(int currentCompletedLvlNumb)
    {
        int nxtSceneIndex = 0;

        switch (currentCompletedLvlNumb)
        {
            case 1:
                nxtSceneIndex = SceneIndex.levelTwo;
                break;
            case 2:
                nxtSceneIndex = SceneIndex.levelThree;
                break;
            default:
                nxtSceneIndex = SceneIndex.mainMenu;
                break;
        }
        return nxtSceneIndex;
    }
}
