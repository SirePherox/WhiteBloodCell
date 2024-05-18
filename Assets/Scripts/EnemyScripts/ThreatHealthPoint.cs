using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ThreatHealthPoint : MonoBehaviour
{
    [SerializeField] private Slider threatHealth_slider;
    public float maxHealthAmount;

    private void OnEnable()
    {
        //reset slider value
        threatHealth_slider.value = 1.0f;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        threatHealth_slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void UpdateHealth(float amount)
    //{
    //    health_txt.text = amount.ToString();
    //    PlayHitAnim();
    //}

    public void UpdateHealth(float amount)
    {
        if(threatHealth_slider
             == null)
        {
            Debug.Log("Slider is null");
        }
        else
        {
            threatHealth_slider.value = amount / maxHealthAmount;
        }
        
    }

    
}
