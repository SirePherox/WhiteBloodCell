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
    public const string NEUTRAL = "Neutral";
}

public class ThreatTypes
{
    public const string BACTERIA = "Bacteria";
    public const string VIRUS = "Virus";
    public const string TOXIN = "Toxin";
}

public class AnimatorTags
{
    public const string THREAT_HIT_TAG = "Hit";
    public const string PLAYER_WALK_LEFT = "WalkLeft";
    public const string PLAYER_WALK_RIGHT = "WalkRight";
    public const string ENGULF_ATTACK = "Weaken";
    public const string WEAKEN_ATTACK = "Weaken";
    public const string KILL_ATTACK = "Kill";
    public const string THREAT_DEAD = "Dead";
    public const string PLAYER_DEAD = "Dead";
    public const string PLAYER_WIN = "Win";
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
    public const string MUSIC_SLIDER = "MusicSlider";
    public const string SFX_SLIDER = "SoundEffectsSlider";
    public const string CURRENT_LEVEL_NUMBER = "CompletedLevelNumber";
}

public class SceneIndex
{
    public const int splashScene = 0;
    public const int mainMenu = 1;
    public const int loadingScene = 2;
    public const int levelOne = 3;
    public const int levelTwo = 4;
    public const int levelThree = 5;

}

