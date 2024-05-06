using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[DefaultExecutionOrder(-10)]
public class ObjectPooler : MonoBehaviour
{
    [Header("Pool Refereebces")]
    [SerializeField] private BulletController killAttackBulletsPrefab;
    [Header("Pool Variables")]
    [SerializeField] private int defaultBulletPoolSize;
    [SerializeField] private int maxAttackBulletPoolSize;
    public ObjectPool<BulletController> killAttackBulletPool;
    private bool collectionCheck = true;
    // Start is called before the first frame update
    void Start()
    {
        killAttackBulletPool = new ObjectPool<BulletController>(CreateKillAttackBullet, GetKillAttackBullet,
                                                            ReturnKillAttackBulletToPool, DestroyKillAttackBullet, collectionCheck,
                                                            defaultBulletPoolSize, maxAttackBulletPoolSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private  BulletController CreateKillAttackBullet()
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
}
