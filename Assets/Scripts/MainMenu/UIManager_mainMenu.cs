using UnityEngine;
using UnityEngine.UI;

public class UIManager_mainMenu : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private LevelSelectorManager lvlSelector;

    [Header("UI References")]
    [SerializeField] private Button playGame_btn;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(lvlSelector == null)
        {
            Debug.LogError("COULDNT CACHE LEVEL SELECTOR, ENSURE ITS ATTACHED IN EDITOR");
        }

        AddButtonEvents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        //save scene to load to playerprefs
        PlayerPrefsManager.Instance.SetNextSceneToLoad(lvlSelector.sceneIndexToLoad);
        //load Loading scene
        SceneLoader.Instance.LoadScene(SceneIndex.loadingScene);
    }

    #region - Level Buttons-
    public void SelectLevel1()
    {
        lvlSelector.UpdateSceneBasedOnLevelSelected(1);
    }

    public void SelectLevel2()
    {
        lvlSelector.UpdateSceneBasedOnLevelSelected(2);
    }

    public void SelectLevel3()
    {
        lvlSelector.UpdateSceneBasedOnLevelSelected(3);
    }
    #endregion


    private void AddButtonEvents()
    {
        playGame_btn.onClick.AddListener(PlayGame);
    }
}
