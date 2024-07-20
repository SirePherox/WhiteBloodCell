using UnityEngine;

public class LevelStats : MonoBehaviour
{
    public float totalTimeForLevel;
    public string healItem = "Cytogen";
    public int levelNumb = 1;

    [Header("Mutate Variables")]
    public int minHealthMultiplier;
    public int maxHealthMultiplier;

    public int minXpMultiplier;
    public int maxXpMultiplier;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundController.Instance.StopMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
