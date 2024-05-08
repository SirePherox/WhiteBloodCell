using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThreatHealthPoint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health_txt;
    private Animator threatAnimator;

    // Start is called before the first frame update
    void Start()
    {
        health_txt = GetComponentInChildren<TextMeshProUGUI>();
        threatAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float amount)
    {
        health_txt.text = amount.ToString();
        PlayHitAnim();
    }

    private void PlayHitAnim()
    {
        threatAnimator.SetTrigger(AnimatorTags.THREAT_HIT_TAG);
    }
}
