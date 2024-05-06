using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Variables")]
    public float playerHealth;
    private float defaultPlayerHealth = 100.0f;

    public PlayerHealthManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {

    }

    public void Heal(float healAmount)
    {

    }
}
