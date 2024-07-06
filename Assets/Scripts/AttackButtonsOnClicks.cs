using UnityEngine;
using UnityEngine.UI;


public class AttackButtonsOnClicks : MonoBehaviour
{

    [Header("Variables")]
    [SerializeField] private float defaultBatteryLevel; //to avoid spamming the attack buttons
    [SerializeField] private float currentBatteryLevel;
    [SerializeField] private Image batterylevel_img;
    [SerializeField] private bool isKillAttack; //tick this to disble incompatible behaviours for the kill attack button
    private Button button;
    private PlayerController playerController;


    private void Awake()
    {
        button = GetComponent<Button>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        playerController = FindFirstObjectByType<PlayerController>();
        if(button == null || playerController == null)
        {
            Debug.LogWarning("COULDN'T CACHE, ATTACK SWITCHING MIGHT NOT WORK");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKillAttack)
        {
            RechargeBattery();
            SetInteractableWithBatteryLevel();
        }

    }

    private void RechargeBattery()
    {
        if(currentBatteryLevel < defaultBatteryLevel)
        {
            currentBatteryLevel += Time.deltaTime; //recharge overtime
        }
    }

    private void OnclickAction(string attackMech)
    {
        //use up the battey
        currentBatteryLevel = 0;
        playerController.OnChangeAttackMechanism?.Invoke(attackMech);
    }

    public void SetToKillAttack()
    {
        OnclickAction(PlayerAttackTypes.KILL_ATTACK);
    }

    public void SetToEngulfAttack()
    {
        OnclickAction(PlayerAttackTypes.ENGULF_ATTACK);
    }

    public void SetToWeakenAttack()
    {
        OnclickAction(PlayerAttackTypes.WEAKEN_ATTACK);
    }

    public void SetToCallImmuneAttack()
    {
        OnclickAction(PlayerAttackTypes.CALLIMMUNE_ATTACK);
    }

    private void BoostBatteryToFull()
    {
        currentBatteryLevel = defaultBatteryLevel;
    }

    private void SetInteractableWithBatteryLevel()
    {
        //disable button when battery not full
        button.interactable = currentBatteryLevel >= defaultBatteryLevel;
        //display battery level
        batterylevel_img.fillAmount = currentBatteryLevel / defaultBatteryLevel;
    }
}
