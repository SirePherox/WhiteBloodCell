using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : SingletonCreator<PlayerPrefsManager>
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetCurrentHealthMultiplier()
    {
        float currentMult = PlayerPrefs.GetFloat(PlayerPrefsNames.THREAT_HEALTH_MULTIPLIER, 1);
        return currentMult;
    }
}
