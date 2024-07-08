using UnityEngine;

public class LevelSelectorManager : MonoBehaviour
{
    public int sceneIndexToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSceneBasedOnLevelSelected(int selectedLvl)
    {
        switch (selectedLvl)
        {
            case 1:
                sceneIndexToLoad = SceneIndex.levelOne;
                break;
            case 2:
                sceneIndexToLoad = SceneIndex.levelTwo;
                break;
            case 3:
                sceneIndexToLoad = SceneIndex.levelThree;
                break;
            default:
                Debug.LogWarning("Couldnt parse the input, loading the first level scene");
                sceneIndexToLoad = SceneIndex.levelOne;
                break;

        }
    }
}
