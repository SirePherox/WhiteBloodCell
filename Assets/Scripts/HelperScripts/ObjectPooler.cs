using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[DefaultExecutionOrder(-10)]
public class ObjectPooler : MonoBehaviour
{
    [Header("Pool References")]
    [SerializeField] private BulletController killAttackBulletsPrefab;
    [SerializeField] private Bacteria bacteriaPrefab;
    [SerializeField] private Virus virusPrefab;
    [SerializeField] private Toxin toxinPrefab;

    [Space]
    [Header("Pool Variables")]
    [SerializeField] private int defaultBulletPoolSize;
    [SerializeField] private int maxAttackBulletPoolSize;
    public ObjectPool<BulletController> killAttackBulletPool;

    [Space]
    [Header("Enemy Variables")]
    [SerializeField] private int defaultThreatPoolSize;
    [SerializeField] private int maxThreatPoolSize;
    public ObjectPool<Bacteria> bacteriaThreatPool;
    public ObjectPool<Virus> virusThreatPool;
    public ObjectPool<Toxin> toxinThreatPool;

    private bool collectionCheck = true;
    // Start is called before the first frame update
    void Start()
    {
        killAttackBulletPool = new ObjectPool<BulletController>(CreateKillAttackBullet, GetKillAttackBullet,
                                                            ReturnKillAttackBulletToPool, DestroyKillAttackBullet, collectionCheck,
                                                            defaultBulletPoolSize, maxAttackBulletPoolSize);

        bacteriaThreatPool = new ObjectPool<Bacteria>(CreateBacteria, GetThreatFromPool,
                                                    ReturnThreatToPool, DestroyThreat, collectionCheck,
                                                       defaultThreatPoolSize, maxThreatPoolSize);
        virusThreatPool = new ObjectPool<Virus>(CreateVirus, GetThreatFromPool,
                                                    ReturnThreatToPool, DestroyThreat, collectionCheck,
                                                       defaultThreatPoolSize, maxThreatPoolSize);

        toxinThreatPool = new ObjectPool<Toxin>(CreateToxin, GetThreatFromPool,
                                            ReturnThreatToPool, DestroyThreat, collectionCheck,
                                               defaultThreatPoolSize, maxThreatPoolSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region -Enemy Pool-
    private Bacteria CreateBacteria()
    {
        Bacteria newBact = Instantiate(bacteriaPrefab);
        return newBact;
    }

    private Virus CreateVirus()
    {
        Virus newVirus = Instantiate(virusPrefab);
        return newVirus;
    }

    private Toxin CreateToxin()
    {
        Toxin newToxin  = Instantiate(toxinPrefab);
        return newToxin;
    }
    private void GetThreatFromPool(BaseThreatController threat)
    {
        threat.gameObject.SetActive(true);
        //ENEMY CAN MUTATE HERE
    }

    private void ReturnThreatToPool(BaseThreatController threat)
    {
        threat.gameObject.SetActive(false);
        //ENEMY CAN MUTATE HERE
    }

    private void DestroyThreat(BaseThreatController threat)
    {
        Destroy(threat);
    }
    #endregion

    #region -Bullet Pool-
    private BulletController CreateKillAttackBullet()
    {
        BulletController newBullet = Instantiate(killAttackBulletsPrefab);
        return newBullet;
    }

    private void GetKillAttackBullet(BulletController bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    public void ReturnKillAttackBulletToPool(BulletController bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void  DestroyKillAttackBullet(BulletController bullet)
    {
        Destroy(bullet);
    }
    #endregion
}
