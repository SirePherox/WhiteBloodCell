using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity;
public class ThreatsManager : MonoBehaviour
{
    [Header("Threat Variables")]
    [SerializeField] private List<Transform> spawnPositions;
    private List<Transform> tempList; // Temporary list for random selection
    private Transform threatParent;


   // [Header("Mutation Variables")]
  

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
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnThreats();
       // SpawnVirusThreats();
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
}
