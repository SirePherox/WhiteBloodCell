using UnityEngine;

public class WeakenerController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damagePower;
    [SerializeField] private float stayAliveDuration;

    private Vector3 posOfFirstThreat;
    /// <summary>
    /// Weaken works by affectnig the XP of threats
    /// after it touches the the first threat, it stays in that position and wait for
    /// sometime,  and affects any other threats that passes through it  for sometime
    /// </summary>
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        posOfFirstThreat = Vector3.zero; //reset on awake
    }

    // Update is called once per frame
    void Update()
    {
        MoveWeakener();
    }

    private void MoveWeakener()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseThreatController>() != null)
        {
            //if weakerner touches an enemy   //deal damage to health
            BaseThreatController threat = other.transform.GetComponent<BaseThreatController>();

            //shoow vfx
            //destroy after sometime
            WeakenMechanism(threat);
        }
    }


    private void WeakenMechanism(BaseThreatController threat)
    {
        //get the transform of the first threat if it hasnt been set
        if (posOfFirstThreat == Vector3.zero)
        {
            Debug.Log("Cached the first contacted threat transform");
            transform.position = threat.gameObject.transform.position;
            moveSpeed = 0.0f; //stop movement
            //start destroy time
            StartCoroutine(DestroyAfterTime());
        }

        //affect all other effects
        switch (threat.threatType)
        {
            case ThreatType.Bacteria:
                threat.GetComponent<Bacteria>().TakeDamage(PlayerAttackTypes.WEAKEN_ATTACK, damagePower);
                break;
            case ThreatType.Virus:
                threat.GetComponent<Virus>().TakeDamage(PlayerAttackTypes.WEAKEN_ATTACK, damagePower);
                break;
            default:
                Debug.LogWarning("COULDN'T HANDLE THE THREAT TYPE, DAMAGE WASNT DEALT");
                break;
        }

    }

    private System.Collections.IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(stayAliveDuration);
        Destroy(this.gameObject);
    }
}
