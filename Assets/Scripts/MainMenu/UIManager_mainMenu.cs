using UnityEngine;
using UnityEngine.UI;

public class UIManager_mainMenu : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private LevelSelectorManager lvlSelector;

    [Header("UI References")]
    [SerializeField] private Button playGame_btn;
    
    
    [Space]
    [Header("Settings Variables")]
    [SerializeField] private Button settings_btn;
    [SerializeField] private Transform settings_panel;
    [SerializeField] private Button closeSettings_btn;

    [Header("Help Variables")]
    [SerializeField] private Button help_btn;
    [SerializeField] private Transform help_panel;
    [SerializeField] private Button closeHelp_btn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(lvlSelector == null)
        {
            Debug.LogError("COULDNT CACHE LEVEL SELECTOR, ENSURE ITS ATTACHED IN EDITOR");
        }

        AddButtonEvents();
#if UNITY_EDITOR
        CloseSettingsPanel();
        CloseHelpPanel();
#endif
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
        settings_btn.onClick.AddListener(OpenSettingsPanel);
        closeSettings_btn.onClick.AddListener(CloseSettingsPanel);
        help_btn.onClick.AddListener(OpenHelpPanel);
        closeHelp_btn.onClick.AddListener(CloseHelpPanel);
    }

    private void OpenSettingsPanel()
    {
        settings_panel.gameObject.SetActive(true);
    }

    private void CloseSettingsPanel()
    {
        settings_panel.gameObject.SetActive(false);
    }

    private void OpenHelpPanel()
    {
        help_panel.gameObject.SetActive(true);
    }

    private void CloseHelpPanel()
    {
        help_panel.gameObject.SetActive(false);
    }
}
