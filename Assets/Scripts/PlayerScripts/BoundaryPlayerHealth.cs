using UnityEngine;

public class BoundaryPlayerHealth : MonoBehaviour
{
    [Header("Script Referencees")]
    private PlayerHealthManager playerHealth;

    /// <summary>
    /// This boundary is respoonsible for dealing damage to player health after threats
    /// escapes player 
    /// </summary>
    ///


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealthManager>();
        if (playerHealth == null)
        {
            Debug.LogWarning("COULDNT CACHE PLAYER HEALTH, WONT BE ABLE TO DEAL DAMAGE");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<BaseThreatController>() != null)
        {
            //deal damage to playerhealth threat based on threattype and remaining health
            ThreatType threatType = other.transform.GetComponent<BaseThreatController>().threatType;
            switch (threatType)
            {
                case ThreatType.Bacteria:
                    playerHealth.TakeDamage(ThreatTypes.BACTERIA, other.transform.GetComponent<Bacteria>().healthController.current_Health);
                    break;
                case ThreatType.Virus:
                    playerHealth.TakeDamage(ThreatTypes.VIRUS, other.transform.GetComponent<Virus>().healthController.current_Health);
                    break;
                default:
                    Debug.LogError("COULDN'T HANDLE THE THREAT, BOUNDARY DAMAGE WASNT DONE");
                    break;
            }
        }
    }
}
