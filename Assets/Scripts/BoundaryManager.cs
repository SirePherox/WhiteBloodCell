using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.GetComponent<BaseEnemyController>() != null)
        {
            Debug.Log("Enemy");
          //return enemy to pool
        }
        else if (other.transform.GetComponent<BulletController>() != null)
        {
            //collider is a bullet
            spawnManager.ReturnKillAttackBulletToPool(other.transform.GetComponent<BulletController>());
        }

    }
}
