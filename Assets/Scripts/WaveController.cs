using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class WaveController : MonoBehaviour
{

    [Header("Script References")]
    [SerializeField] private LevelStats currentLevelStats;
    


    [Header( "Wave Variables")]
    [SerializeField] private int numberOfWavesForThisLevel;
    [SerializeField] private int currentWaveNumb;
    private float timeForAWave = 20.0f;
    private float waveDelayInterval = 9.0f;
    [SerializeField] private float currentTimeForThisWave;
    [SerializeField] private bool canStartTimeForCurrentWave = false;

    //EVENTS
    public UnityEvent<int> OnWaveStart;
    public UnityEvent<int> OnWaveEnd;

    public static WaveController Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetOnNewLevelLoad();
    }

    // Update is called once per frame
    void Update()
    {
        StartCurrentWaveClock();
    }


    private void ResetOnNewLevelLoad()
    {
        currentLevelStats = FindFirstObjectByType<LevelStats>();
        if(currentLevelStats == null)
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
       if(currentWaveNumb < numberOfWavesForThisLevel) //wave for this level hasn't been completed
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
            OnWaveStart?.Invoke(currentWaveNumb);

            currentTimeForThisWave -= Time.deltaTime;
            if(currentTimeForThisWave <= 0.0f)
            {
                //time for this wave ended
                currentTimeForThisWave = 0.0f;
                OnWaveEnded();
            }
        }
        
    }

    private void OnWaveEnded()
    {
        OnWaveEnd?.Invoke(currentWaveNumb);

        canStartTimeForCurrentWave = false;
        currentTimeForThisWave = timeForAWave;
        WaveControl();
    }

    /// <summary>
    /// Returns currentWaveTime divided by totalTimeForAWave
    /// </summary>
    public float GetWaveTimerRate()
    {
        return currentTimeForThisWave / timeForAWave;
    }
}
