using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTagsAndNames 
{
    
}

public class PlayerAttackTypes
{
    public const string KILL_ATTACK = "KillAttack";
    public const string ENGULF_ATTACK = "EngulfAttack";
    public const string WEAKEN_ATTACK = "WeakenAttack";
    public const string CALLIMMUNE_ATTACK = "CallImmuneAttack";
}

public class ThreatTypes
{
    public const string BACTERIA = "Bacteria";
    public const string VIRUS = "Virus";
}

public class AnimatorTags
{
    public const string THREAT_HIT_TAG = "Hit";
}

public class StandardThreatHealth
{
    public const float BACTERIA_HEALTH = 3.0f;
    public const float VIRUS_HEALTH = 5.0f;

    public const float BACTERIA_XP = 10.0f;
    public const float VIRUS_XP = 10.0f;
}

public class PlayerPrefsNames
{
    public const string THREAT_HEALTH_MULTIPLIER = "ThreatHealthMultiplier";
    public const string THREAT_XP_MULTIPLIER = "ThreatXPMultiplier";
    public const string NEXT_SCENE_TO_LOAD = "NextSceneToLoad";
}

public class SceneIndex
{
    public const int mainMenu = 0;
    public const int loadingScene = 1;
    public const int levelOne = 2;
    public const int levelTwo = 3;
    
}
