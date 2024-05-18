using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreatHealthController : MonoBehaviour
{
    [Header("Variables")]
    [HideInInspector] public float default_moveSpeed_XP;
    private float current_moveSpeed_XP;
    [HideInInspector] public float default_Health;
   // [HideInInspector]
    public float current_Health;

    [Space]
    [SerializeField] private Slider threatHealth_slider;
    public float maxHealthAmount;
    // Start is called before the first frame update
    void Start()
    {
        threatHealth_slider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        current_Health -= amount;
        UpdateHealth();
    }

    public void DieInstantly()
    {
        current_Health = 0;
        UpdateHealth();
    }
    public void ReduceSpeed_XP(float amount)
    {
        current_moveSpeed_XP -= amount;
    }

    private void UpdateHealth()
    {
        if (threatHealth_slider == null)
        {
            Debug.Log("Slider is null");
        }
        else
        {
            threatHealth_slider.value = current_Health / default_Health;
            //threatHealth_slider.value = amount / maxHealthAmount;
        }

    }

    public bool IsThreatDead()
    {
        return current_Health <= 0.0f;
    }

    public void ResetSliderValue()
    {
        //set slider to max
        threatHealth_slider.value = 1.0f;
    }
}
