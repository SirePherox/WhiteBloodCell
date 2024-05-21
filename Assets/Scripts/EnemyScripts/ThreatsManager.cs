using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity;
public class ThreatsManager : MonoBehaviour
{
    [Header("Script References")]
    private LevelStats levelStats;

    [Header("Threat Variables")]
    [SerializeField] private List<Transform> spawnPositions;
    private List<Transform> tempList; // Temporary list for random selection
    private Transform threatParent;
    private bool canSpawnThreats = false;

    [Header("Mutation Variables")]
    private float minHealthMultiplier = 1.0f;
    private float maxHealthMultiplier = 5.0f;

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
        MutateHealthMultiplier();

        //cache scripts
        levelStats = FindFirstObjectByType<LevelStats>();
        //
        WaveController.Instance.OnWaveStart.AddListener(OnNewWaveStarted);
        WaveController.Instance.OnWaveEnd.AddListener(OnCurrentWaveEnded);
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

    }

    private void SpawnVirusThreat()
    {
        Virus newVirus = SpawnManager.Instance.GetVirus();
        newVirus.transform.position = GetRandomTransform();
        newVirus.transform.parent = threatParent;

        //set or reset default values
        newVirus.healthController.current_Health = StandardThreatHealth.VIRUS_HEALTH * PlayerPrefsManager.Instance.GetCurrentHealthMultiplier();
        newVirus.healthController.default_Health = StandardThreatHealth.VIRUS_HEALTH * PlayerPrefsManager.Instance.GetCurrentHealthMultiplier();
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

    private void OnNewWaveStarted(int currentWaveNumb)
    {
        Debug.Log("Wave numb is : " + currentWaveNumb);
        canSpawnThreats = true;

    }

    private void OnCurrentWaveEnded(int currentWaveNumb)
    {
        Debug.Log("The wave that ended: " + currentWaveNumb);
        canSpawnThreats = false;
    }

    private void MutateThreats(int currentWaveNumb)
    {
        //mutate threat based on the current level and wave numb
        int currentLevel = levelStats.levelNumb;
        int waveNumb = currentWaveNumb;



    }

    private void MutateHealthMultiplier()
    {
        int currentLevel = levelStats.levelNumb;
        float newHealthMultiplier = Mathf.Clamp(currentLevel, minHealthMultiplier, maxHealthMultiplier);
        PlayerPrefsManager.Instance.SetHealthMultiplier(newHealthMultiplier);
    }

   
}
