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


    private float nextSpawnTime = 0.0f;
    private float spawnRate = 1.5f;

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
    }

    private void SpawnThreats()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnBacteriaThreat();
            nextSpawnTime = Time.time + 1f / spawnRate; // Update next fire time based on fire rate
        }
    }

    private void SpawnBacteriaThreat()
    {
        Bacteria newBact = SpawnManager.Instance.GetBacteria();
        newBact.transform.position = GetRandomTransform();
        newBact.transform.parent = threatParent;
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
