using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Scripts References")]
    [SerializeField] private ObjectPooler objectPool;

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

    public Bacteria GetBacteria()
    {
        return objectPool.bacteriaEnemyPool.Get();
    }

    public void ReturnBacteriaToPool(Bacteria threat)
    {
        objectPool.bacteriaEnemyPool.Release(threat);
    }

    public BulletController GetKillAttackBullet()
    {
        return objectPool.killAttackBulletPool.Get();
    }

    public void ReturnKillAttackBulletToPool(BulletController bullet)
    {
        objectPool.killAttackBulletPool.Release(bullet);
    }
}
