using UnityEngine;
using System;

public class EngulferController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damagePower; //since it kills them automatically
    [SerializeField] private float timeToSelfDestroy;
    private Transform transformToFollow;

    /// <summary>
    /// Engulf kills enemy immediately, but it's a skill that requires a lot of grinding
    /// and takes a toll on the player 
    /// </summary>
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformToFollow = null;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEngulfer();
        if(transformToFollow != null)
        {
            transform.position = transformToFollow.position;
        }
    }

    private void MoveEngulfer()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseThreatController>() != null)
        {
            //if engulfer touches an enemy   //deal damage to health
            BaseThreatController threat = other.transform.GetComponent<BaseThreatController>();

            //shoow vfx
            //destroy after sometime
            EngulfingMechanism(threat);
        }
    }

    private void EngulfingMechanism(BaseThreatController threat)
    {
        //continously follow the threat
        transformToFollow = threat.transform;

        //destroy both after sometime
        StartCoroutine(DestroyAfterTime(threat));
    }

    private System.Collections.IEnumerator DestroyAfterTime(BaseThreatController threat)
    {
        Debug.Log("Attemptong");
        yield return new WaitForSeconds(timeToSelfDestroy);
        switch (threat.threatType)
        {
            case ThreatType.Bacteria:
                threat.GetComponent<Bacteria>().TakeDamage(PlayerAttackTypes.ENGULF_ATTACK, damagePower);
                break;
            case ThreatType.Virus:
                threat.GetComponent<Virus>().TakeDamage(PlayerAttackTypes.ENGULF_ATTACK, damagePower);
                break;
            default:
                Debug.LogWarning("COULDN'T HANDLE THE THREAT TYPE, DAMAGE WASNT DEALT");
                break;
        }
        Debug.Log("Now   Attemptong");
        Destroy(this.gameObject);
    }
}
