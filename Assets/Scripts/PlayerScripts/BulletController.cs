using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BaseThreatController>() != null)
        {
            //if bullet touches an enemy
            //deal damage
            BaseThreatController enemy = other.transform.GetComponent<BaseThreatController>();
            Debug.Log("Threat type: " + enemy.threatType);
            //return to pool based on threat type
            switch (enemy.threatType)
            {
                case ThreatType.Bacteria:
                    SpawnManager.Instance.ReturnBacteriaToPool(enemy.GetComponent<Bacteria>());
                    break;
                default:
                    Debug.LogWarning("COULDN'T HANDLE THE THREAT TYPE, OBJECT WASNT RETURNED TO POOL");
                    break;
            }
           
            //shoow vfx

            Debug.Log("Bullet hit enemy here");
            SpawnManager.Instance.ReturnKillAttackBulletToPool(this);
        }
    }
}
