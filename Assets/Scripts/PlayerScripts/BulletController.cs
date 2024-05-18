using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damagePower = 1.0f;
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
            //if bullet touches an enemy   //deal damage to health
            BaseThreatController threat = other.transform.GetComponent<BaseThreatController>();
            switch (threat.threatType)
            {
                case ThreatType.Bacteria:
                    threat.GetComponent<Bacteria>().TakeDamage(PlayerAttackTypes.KILL_ATTACK, damagePower);
                    break;
                case ThreatType.Virus:
                    threat.GetComponent<Virus>().TakeDamage(PlayerAttackTypes.KILL_ATTACK, damagePower);
                    break;
                default:
                    Debug.LogWarning("COULDN'T HANDLE THE THREAT TYPE, OBJECT WASNT RETURNED TO POOL");
                    break;
            }
           
            //shoow vfx
            SpawnManager.Instance.ReturnKillAttackBulletToPool(this);
        }
    }
}
