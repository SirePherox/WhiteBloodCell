using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 0 - pause
    /// 1 - resume
    /// 2 - quit
    /// </summary>
    public UnityAction<int> OnGameStateChanged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
