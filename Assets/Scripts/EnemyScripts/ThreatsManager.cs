using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity;
//[DefaultExecutionOrder(10)]
public class ThreatsManager : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField]private LevelStats levelStats;

    [Header("Threat Variables")]
    [SerializeField] private List<Transform> spawnPositions;
    private List<Transform> tempList; // Temporary list for random selection
    private Transform threatParent;
    private bool canSpawnThreats = false;


    [Space]
    [SerializeField]
    private float bacteriaNextSpawnTime = 0.0f;
    [SerializeField]
    private float virusNextSpawnTime = 0.0f;

    [SerializeField] private float bacteriaSpawnRate;
    [SerializeField] private float virusSpawnRate;

    private void Awake()
    {
        threatParent = GetComponent<Transform>();

    }
    // Start is called before the first frame update
    void Start()
    {
        //cache scripts
        levelStats = FindFirstObjectByType<LevelStats>();
        //
        WaveController.Instance.OnWaveStart.AddListener(OnNewWaveStarted);
        WaveController.Instance.OnWaveEnd.AddListener(OnCurrentWaveEnded);

        MutateHealthMultiplier();
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawnThreats)
        {
            SpawnThreats();
        }
    }

    private void SpawnThreats()
    {
        if (Time.time > bacteriaNextSpawnTime)
        {
            SpawnBacteriaThreat();
            bacteriaNextSpawnTime = Time.time + 1f / bacteriaSpawnRate; // Update next spawn time based on spawn rate
        }

        if (Time.time > virusNextSpawnTime)
        {
            SpawnVirusThreat();
            virusNextSpawnTime = Time.time + 1f / virusSpawnRate;
        }
    }

    private void SpawnBacteriaThreat()
    {
        Bacteria newBact = SpawnManager.Instance.GetBacteria();
        newBact.transform.position = GetRandomTransform();
        newBact.transform.parent = threatParent;

        //set or reset default values here 
       // Debug.Log("Will attempt to set health: " + StandardThreatHealth.BACTERIA_HEALTH * PlayerPrefsManager.Instance.GetCurrentHealthMultiplier());
        newBact.healthController.current_Health = StandardThreatHealth.BACTERIA_HEALTH * PlayerPrefsManager.Instance.GetCurrentHealthMultiplier();
        newBact.healthController.default_Health = StandardThreatHealth.BACTERIA_HEALTH * PlayerPrefsManager.Instance.GetCurrentHealthMultiplier();

        newBact.healthController.default_XP = StandardThreatHealth.BACTERIA_XP * PlayerPrefsManager.Instance.GetCurrentXPMultiplier();
        newBact.healthController.current_XP = StandardThreatHealth.BACTERIA_XP * PlayerPrefsManager.Instance.GetCurrentXPMultiplier();
    }

    private void SpawnVirusThreat()
    {
        Virus newVirus = SpawnManager.Instance.GetVirus();
        newVirus.transform.position = GetRandomTransform();
        newVirus.transform.parent = threatParent;

        //set or reset default values
        newVirus.healthController.current_Health = StandardThreatHealth.VIRUS_HEALTH * PlayerPrefsManager.Instance.GetCurrentHealthMultiplier();
        newVirus.healthController.default_Health = StandardThreatHealth.VIRUS_HEALTH * PlayerPrefsManager.Instance.GetCurrentHealthMultiplier();

        newVirus.healthController.default_XP = StandardThreatHealth.VIRUS_XP * PlayerPrefsManager.Instance.GetCurrentXPMultiplier();
        newVirus.healthController.current_XP = StandardThreatHealth.VIRUS_XP * PlayerPrefsManager.Instance.GetCurrentXPMultiplier();
    }
    public Vector3 GetRandomTransform()
    {
        if (tempList == null || tempList.Count == 0)
        {
            // Reset if temp list is empty or not initialized
            tempList = new List<Transform>(spawnPositions); // Copy original list to temp list
        }

        int randomIndex = UnityEngine.Random.Range(0, tempList.Count);
        Transform randomTransform = tempList[randomIndex];
        tempList.RemoveAt(randomIndex); // Remove used transform from temp list
        
        return randomTransform.position;
    }

    private void OnNewWaveStarted(int currentWaveNum)
    {
        Debug.Log("Wave started numb is : " + currentWaveNum);
        canSpawnThreats = true;
        MutateThreats(currentWaveNum);
    }

    private void OnCurrentWaveEnded(int currentWaveNumb)
    {
        Debug.Log("The wave that ended: " + currentWaveNumb);
        canSpawnThreats = false;
    }

    private void MutateThreats(int currentWaveNumb)
    {
        //mutate
        Debug.Log("Mutating...");
        MutateHealthMultiplier();
        MutateXpMultiplier(currentWaveNumb);
    }

    private void MutateHealthMultiplier()
    {
        int currentLevel = levelStats.levelNumb;
        //todo A math calc can be done on currentlevel to make it random or something else
        //it will be clamped so the result is fine
        float newHealthMultiplier = Mathf.Clamp(currentLevel, levelStats.minHealthMultiplier, levelStats.maxHealthMultiplier);
        PlayerPrefsManager.Instance.SetHealthMultiplier(newHealthMultiplier);
    }

    private void MutateXpMultiplier(int currentWaveNumb)
    {
        //todo a math calc can be done on currentWaveNumber to make it random
        // the final value is clamped so the reuslt is fine
        float calcXpMultiplier = currentWaveNumb * 1;
        float newXpMultiplier = Mathf.Clamp(calcXpMultiplier, levelStats.minXpMultiplier, levelStats.maxXpMultiplier);
        PlayerPrefsManager.Instance.SetXPMultiplier(newXpMultiplier);
    }
   
}
