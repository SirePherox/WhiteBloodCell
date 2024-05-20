using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUIUpdater : MonoBehaviour
{

    [Header("Player UI Elements")]
    private Slider slider;
    private PlayerHealthManager playerHealth;

    public enum UIElement
    {
        Health,
        XP
    }

    public UIElement myElementType;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealthManager>();
        if(playerHealth == null)
        {
            Debug.LogWarning("COULDNT CACHE PLAYER HEALTH, WONT BE ABLE TO SHOW PLAYEER HEALTH UI");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(myElementType == UIElement.Health)
        {
            slider.value = playerHealth.currentPlayerHealthRate;
        }
    }
}
