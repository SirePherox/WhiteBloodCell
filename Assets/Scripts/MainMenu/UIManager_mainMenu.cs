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

    [Header("Credits Variables")]
    [SerializeField] private Button credits_btn;
    [SerializeField] private Transform credits_panel;
    [SerializeField] private Button closeCredits_btn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMusic();

        if (lvlSelector == null)
        {
            Debug.LogError("COULDNT CACHE LEVEL SELECTOR , ENSURE ITS ATTACHED PROPERLY REFERENCED");
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
        SceneLoader.Instance.LoadSceneWithLoadingScene(lvlSelector.sceneIndexToLoad);
    }

   


    private void AddButtonEvents()
    {
        playGame_btn.onClick.AddListener(PlayGame);

        settings_btn.onClick.AddListener(OpenSettingsPanel);
        closeSettings_btn.onClick.AddListener(CloseSettingsPanel);

        help_btn.onClick.AddListener(OpenHelpPanel);
        closeHelp_btn.onClick.AddListener(CloseHelpPanel);

        credits_btn.onClick.AddListener(OpenCreditsPanel);
        closeCredits_btn.onClick.AddListener(CloseCreditsPanel);
    }

    private void OpenSettingsPanel()
    {
        SoundController.Instance.PlayButtonClick();
        settings_panel.gameObject.SetActive(true);
    }

    private void CloseSettingsPanel()
    {
        SoundController.Instance.PlayButtonClick();
        settings_panel.gameObject.SetActive(false);
    }

    private void OpenHelpPanel()
    {
        SoundController.Instance.PlayButtonClick();
        help_panel.gameObject.SetActive(true);
    }

    private void CloseHelpPanel()
    {
        SoundController.Instance.PlayButtonClick();
        help_panel.gameObject.SetActive(false);
    }

    private void OpenCreditsPanel()
    {
        SoundController.Instance.PlayButtonClick();
        credits_panel.gameObject.SetActive(true);
    }

    private void CloseCreditsPanel()
    {
        SoundController.Instance.PlayButtonClick();
        credits_panel.gameObject.SetActive(false);
    }

    private void PlayMusic()
    {
        SoundController.Instance.PlayMainMenuBGMusic();
    }
}
