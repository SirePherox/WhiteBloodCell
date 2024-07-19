using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Script References")]
    private GameStateManager gameState;

    [Header("UI References")]
    [SerializeField] private Image waveDelayUi_img;
    [SerializeField] private Image waveTimer_img;
    [SerializeField] private Button pause_btn;
   
    

    [Header("Pause Variables")]
    [SerializeField] private Transform pausePanel;
    [SerializeField] private Button resume_btn;
    [SerializeField] private Button mainMenu_btn;

    [Header("Level Failed Variables")]
    [SerializeField] private GameObject levelFailed_panel;
    [SerializeField] private Button mainMenu_lvlFailed;
    [SerializeField] private Button tryAgain_lvlFailed;

    [Header("Level Success Variables")]
    [SerializeField] private GameObject levelCompleted_panel;
    [SerializeField] private Button mainMenu_lvlCompleted;
    [SerializeField] private Button nextLevel_lvlCompleted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaveController.Instance.OnWaveStart.AddListener(HideDelayUI);
        WaveController.Instance.OnWaveEnd.AddListener(ShowWaveDelayUI);
        AddButtonOnclickEvents();
        ResumeGame(); //to autohide the pause panel if in case its on

        gameState = GameStateManager.Instance;
        gameState.OnGameSessionEndedUI.AddListener(ShowSessionEnd);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void ShowWaveDelayUI(int currentWaveNumb)
    {
        waveDelayUi_img.gameObject.SetActive(true);
        
    }

    private void HideDelayUI(int currentWaveNumb)
    {
        waveDelayUi_img.gameObject.SetActive(false);
        
    }

    private void UpdateUI()
    {
        waveTimer_img.fillAmount = WaveController.Instance.GetWaveTimerRate();
    }

    private void PauseGame()
    {
        SoundController.Instance.PlayButtonClick();
       GameStateManager.Instance.OnGameStateChanged?.Invoke(0);
        pausePanel.gameObject.SetActive(true);
        GameStateManager.Instance.StopTimeScale();
    }

    private void ResumeGame()
    {
        SoundController.Instance.PlayButtonClick();
        GameStateManager.Instance.OnGameStateChanged?.Invoke(1);
        pausePanel.gameObject.SetActive(false);
        GameStateManager.Instance.StartTimeScale();
    }

    //private void MainMenu()
    //{
    //    //save scene to load to playerprefs
    //    PlayerPrefsManager.Instance.SetNextSceneToLoad(SceneIndex.mainMenu);
    //    Time.timeScale = 1;
    //    //load Loading scene
    //    SceneLoader.Instance.LoadScene(SceneIndex.loadingScene);
    //}

    private void AddButtonOnclickEvents()
    {
        //gameplay
        pause_btn.onClick.AddListener(PauseGame);

        //pause panel
        resume_btn.onClick.AddListener(ResumeGame);
        mainMenu_btn.onClick.AddListener(LoadMainMenuScene);

        //level failed panel
        mainMenu_lvlCompleted.onClick.AddListener(LoadMainMenuScene);
        tryAgain_lvlFailed.onClick.AddListener(RetryLevel);

        //level completed panel
        mainMenu_lvlCompleted.onClick.AddListener(LoadMainMenuScene);
        nextLevel_lvlCompleted.onClick.AddListener(LoadNextLevel);
    }
    private void ShowSessionEnd(int sessionValue)
    {
        if (sessionValue == 1)
        {
            ShowLevelCompleted();
        }
        else
        {
            ShowLevelFailed();
        }
    }

    private void ShowLevelFailed()
    {
        levelFailed_panel.SetActive(true);
    }

    private void ShowLevelCompleted()
    {
        levelCompleted_panel.SetActive(true);
    }

    private void LoadMainMenuScene()
    {
        SoundController.Instance.PlayButtonClick();
        SceneLoader.Instance.LoadSceneWithLoadingScene(SceneIndex.mainMenu);
    }

    private void RetryLevel()
    {
        SoundController.Instance.PlayButtonClick();
        SceneLoader.Instance.LoadSceneWithLoadingScene(SceneLoader.Instance.GetCurrentSceneIndex());
    }

    private void LoadNextLevel()
    {
        SoundController.Instance.PlayButtonClick();
        int currentClearedLvl = PlayerPrefsManager.Instance.GetLevelCompletedNumber();
        int nxtLvlSceneIndex = SceneLoader.Instance.GetNextLevelSceneIndex(currentClearedLvl);
        SceneLoader.Instance.LoadSceneWithLoadingScene(nxtLvlSceneIndex) ;
    }
}
