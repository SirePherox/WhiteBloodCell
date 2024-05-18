using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[DefaultExecutionOrder(-10)]
public class ObjectPooler : MonoBehaviour
{
    [Header("Pool Refereebces")]
    [SerializeField] private BulletController killAttackBulletsPrefab;
    [SerializeField] private Bacteria bacteriaPrefab;
    [SerializeField] private Virus virusPrefab;

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
