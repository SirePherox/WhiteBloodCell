using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class WaveController : MonoBehaviour
{

    [Header("Script References")]
    [SerializeField] private LevelStats currentLevelStats;
    private GameStateManager gameState;



    [Header("Wave Variables")]
    [SerializeField] private int numberOfWavesForThisLevel;
    private int currentWaveNumb;
    private float timeForAWave = 20.0f;
    private float waveDelayInterval = 9.0f;
    [SerializeField] private float currentTimeForThisWave;
    [SerializeField] private bool canStartTimeForCurrentWave = false;
    private float timeDelayBeforeShowingWin = 3.0f;

    //EVENTS
    public UnityEvent<int> OnWaveStart;
    public UnityEvent<int> OnWaveEnd;
    private bool hasInvokedWaveStart;

    public static WaveController Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = GameStateManager.Instance;
        //
        ResetOnNewLevelLoad();
        hasInvokedWaveStart = false;

        OnWaveEnd.AddListener(CheckLevelCompleted);
     
    }

    // Update is called once per frame
    void Update()
    {
        StartCurrentWaveClock();
    }


    private void ResetOnNewLevelLoad()
    {
        currentLevelStats = FindFirstObjectByType<LevelStats>();
        if (currentLevelStats == null)
        {
            Debug.LogError("COULDNT CACHE SCRIPTS, LEVEL CAN'T LOAD");
            return;
        }

        numberOfWavesForThisLevel = (int)(currentLevelStats.totalTimeForLevel / timeForAWave);
        currentWaveNumb = 0;
        currentTimeForThisWave = timeForAWave;
        //start a wave
        WaveControl();
    }

    private void WaveControl()
    {
        if (currentWaveNumb < numberOfWavesForThisLevel) //wave for this level hasn't been completed
        {
            StartCoroutine(StartWaveAfterDelay());
        }

    }
    private IEnumerator StartWaveAfterDelay()
    {
        currentWaveNumb++;
        yield return new WaitForSeconds(waveDelayInterval);
        canStartTimeForCurrentWave = true;
    }

    private void StartCurrentWaveClock()
    {
        if (canStartTimeForCurrentWave)
        {
            CallWaveStartOneTime();

            currentTimeForThisWave -= Time.deltaTime;
            if (currentTimeForThisWave <= 0.0f)
            {
                //time for this wave ended
                currentTimeForThisWave = 0.0f;
                OnWaveEnded();
            }
        }

    }

    private void CallWaveStartOneTime()
    {
        if (!hasInvokedWaveStart)
        {
            OnWaveStart?.Invoke(currentWaveNumb);
            hasInvokedWaveStart = true;
        }
    }


    private void OnWaveEnded()
    {
        OnWaveEnd?.Invoke(currentWaveNumb);

        canStartTimeForCurrentWave = false;
        currentTimeForThisWave = timeForAWave;
        hasInvokedWaveStart = false; //reset after wave ended
        WaveControl();
    }

    private void CheckLevelCompleted(int lvlNumb)
    {
        if(numberOfWavesForThisLevel == lvlNumb)
        {
            Debug.Log("Level completed success");
            StartCoroutine(OnLevelCompleted());
        }
    }

    private IEnumerator OnLevelCompleted()
    {
        yield return new WaitForSeconds(timeDelayBeforeShowingWin);
        PlayerPrefsManager.Instance.SetLevelCompletedNumber(currentLevelStats.levelNumb);
        gameState.OnGameSessionEnded?.Invoke(1);
        StartCoroutine(nameof(StopScale));
    }
    /// <summary>
    /// Returns currentWaveTime divided by totalTimeForAWave
    /// </summary>
    public float GetWaveTimerRate()
    {
        return currentTimeForThisWave / timeForAWave;
    }

    private IEnumerator StopScale()
    {
        float timeDelay = 4.0f; //appxmtely time needed for the win animation to finish playing
        yield return new WaitForSeconds(timeDelay);
        gameState.StopTimeScale();
    }
}
