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
        float currentMult = PlayerPrefs.GetFloat(PlayerPrefsNames.THREAT_HEALTH_MULTIPLIER, 1f);
        return currentMult;
    }

    public void SetHealthMultiplier(float newValue)
    {
        PlayerPrefs.SetFloat(PlayerPrefsNames.THREAT_HEALTH_MULTIPLIER, newValue);
    }

    public float GetCurrentXPMultiplier()
    {
        float currentXP = PlayerPrefs.GetFloat(PlayerPrefsNames.THREAT_XP_MULTIPLIER, 1f);
        return currentXP;
    }

    public void SetXPMultiplier(float newValue)
    {
        PlayerPrefs.SetFloat(PlayerPrefsNames.THREAT_XP_MULTIPLIER, newValue);
    }

    public void SetNextSceneToLoad(int sceneIndex)
    {
        //check if index is correct or can be accessed
        //todo to ensure player don't rig and send an index of a locked level
        PlayerPrefs.SetInt(PlayerPrefsNames.NEXT_SCENE_TO_LOAD, sceneIndex);
    }

    public int GetNextSceneToLoad()
    {
        return PlayerPrefs.GetInt(PlayerPrefsNames.NEXT_SCENE_TO_LOAD, SceneIndex.mainMenu);
    }
}
