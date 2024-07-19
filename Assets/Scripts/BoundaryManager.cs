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
            //return threat to pool based on type
            ThreatType threatType = other.transform.GetComponent<BaseThreatController>().threatType;
            switch (threatType)
            {
                case ThreatType.Bacteria:
                    SpawnManager.Instance.ReturnBacteriaToPool(other.transform.GetComponent<Bacteria>());
                    break;
                case ThreatType.Virus:
                    SpawnManager.Instance.ReturnVirusToPool(other.transform.GetComponent<Virus>());
                    break;
                case ThreatType.Toxin:
                    SpawnManager.Instance.ReturnToxinToPool(other.transform.GetComponent<Toxin>());
                    break;
                default:
                    Debug.LogError("COULDN'T HANDLE THE THREAT, THREAT WASNT RETURNED TO POOL");
                    break;
            }
        }
        else if (other.transform.GetComponent<BulletController>() != null)
        {
            //collider is a bullet
            SpawnManager.Instance.ReturnKillAttackBulletToPool(other.transform.GetComponent<BulletController>());
        }

    }
}
