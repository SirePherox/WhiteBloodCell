using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
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
        if(other.transform.GetComponent<BaseThreatController>() != null)
        {
            Debug.Log("Enemy");
            //return enemy to pool
            SpawnManager.Instance.ReturnBacteriaToPool(other.transform.GetComponent<Bacteria>());
        }
        else if (other.transform.GetComponent<BulletController>() != null)
        {
            //collider is a bullet
            SpawnManager.Instance.ReturnKillAttackBulletToPool(other.transform.GetComponent<BulletController>());
        }

    }
}
