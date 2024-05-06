using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float default_moveSpeed_XP;
    private float current_moveSpeed_XP;
    [SerializeField] private float default_Health;
    public float current_Health;
    // Start is called before the first frame update
    void Start()
    {
        current_Health = default_Health;
        current_moveSpeed_XP = default_moveSpeed_XP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(float amount)
    {
        current_Health -= amount;
    }

    public void ReduceSpeed_XP(float amount)
    {
        current_moveSpeed_XP -= amount;
    }

    
}
