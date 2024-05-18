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
}

public class PlayerPrefsNames
{
    public const string THREAT_HEALTH_MULTIPLIER = "ThreatHealthMultiplier";
}
