using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Scripts References")]
    [SerializeField] private ObjectPooler objectPool;

    [Header("Prefabs")]
    [SerializeField] private EngulferController engulfPrefab;
    [SerializeField] private WeakenerController weakenPrefab;

    public static SpawnManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EngulferController GetEngulfer()
    {
        EngulferController newEngulf = Instantiate(engulfPrefab);
        return newEngulf;
    }

    public WeakenerController GetWeakener()
    {
        WeakenerController newWeak = Instantiate(weakenPrefab);
        return newWeak;
    }

    public Bacteria GetBacteria()
    {
        return objectPool.bacteriaThreatPool.Get();
    }

    public void ReturnBacteriaToPool(Bacteria threat)
    {
        objectPool.bacteriaThreatPool.Release(threat);
    }

    public Virus GetVirus()
    {
        return objectPool.virusThreatPool.Get();
    }

    public void ReturnVirusToPool(Virus threat)
    {
        objectPool.virusThreatPool.Release(threat);
    }

    public BulletController GetKillAttackBullet()
    {
        return objectPool.killAttackBulletPool.Get();
    }

    public void ReturnKillAttackBulletToPool(BulletController bullet)
    {
        if (bullet.gameObject.activeInHierarchy) //an attempt to avoid releasing an object that has been released already
        {
            objectPool.killAttackBulletPool.Release(bullet);
        }
       
    }
}
