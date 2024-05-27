using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ThreatHealthController : MonoBehaviour
{
    [Header("Variables")]
    [HideInInspector] public float default_XP;
    //[HideInInspector]
    public float current_XP;
    [HideInInspector] public float default_Health;
    [HideInInspector] public float current_Health;

    [Space]
    [SerializeField] private Slider threatHealth_slider;
    [SerializeField] private Slider threatXP_slider;
    public float maxHealthAmount;

    //EVENTS
    public UnityEvent<float> OnDamageToXP; //returns the slider value of xp remaining

    // Start is called before the first frame update
    void Start()
    {
        threatHealth_slider = GetComponentInChildren<ThreatHealthPoint>().GetComponent<Slider>();
        threatXP_slider = GetComponentInChildren<ThreatXPPoint>().GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHealthDamage(float amount)
    {
        current_Health -= amount;
        UpdateHealth();
    }

    public void DieInstantly()
    {
        current_Health = 0;
        UpdateHealth();
    }

    public void TakeXPDamage(float amount)
    {
        current_XP -= amount;
        UpdateXP();
    }

    private void UpdateHealth()
    {
        if (threatHealth_slider == null)
        {
            Debug.Log("Health Slider is null");
        }
        else
        {
            threatHealth_slider.value = current_Health / default_Health;
        }

    }

    private void UpdateXP()
    {
        if(threatXP_slider == null)
        {
            Debug.Log("XP Slider is null");
        }
        else
        {
            threatXP_slider.value = current_XP / default_XP;
            //return the remaining % of XP
            Debug.Log("Sednig the event..");
            OnDamageToXP?.Invoke(current_XP / default_XP);
        }
    }

    public bool IsThreatDead()
    {
        return current_Health <= 0.0f;
    }

    public void ResetHealthSliderValue()
    {
        //set slider to max
        threatHealth_slider.value = 1.0f;
    }

    public void ResetXPSliderValue()
    {
        //set slideer to max
        threatXP_slider.value = 1.0f;
    }
}
