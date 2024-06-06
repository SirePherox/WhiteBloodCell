using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image waveDelayUi_img;
    [SerializeField] private Image waveTimer_img;
    [SerializeField] private Button pause_btn;

    [Header("Pause Variables")]
    [SerializeField] private Transform pausePanel;
    [SerializeField] private Button resume_btn;
    [SerializeField] private Button mainMenu_btn;

    public UnityAction<string> OnChangeAttackMechanism;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaveController.Instance.OnWaveStart.AddListener(HideDelayUI);
        WaveController.Instance.OnWaveEnd.AddListener(ShowWaveDelayUI);
        AddButtonOnclickEvents();
        ResumeGame(); //to autohide the pause panel if in case its on
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
       GameStateManager.Instance.OnGameStateChanged?.Invoke(0);
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        GameStateManager.Instance.OnGameStateChanged?.Invoke(1);
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void MainMenu()
    {
        //save scene to load to playerprefs
        PlayerPrefsManager.Instance.SetNextSceneToLoad(SceneIndex.mainMenu);
        Time.timeScale = 1;
        //load Loading scene
        SceneLoader.Instance.LoadScene(SceneIndex.loadingScene);
    }

    private void AddButtonOnclickEvents()
    {
        pause_btn.onClick.AddListener(PauseGame);
        resume_btn.onClick.AddListener(ResumeGame);
        mainMenu_btn.onClick.AddListener(MainMenu);
    }
}
