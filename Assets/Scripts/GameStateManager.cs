using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-10)]
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

    /// <summary>
    /// 0 - Level Failed
    /// 1 - Level Completed
    /// </summary>
    public UnityEvent<int> OnGameSessionEnded;

    /// <summary>
    /// Same function as OnGameSessionEnded;
    /// But for the UI, as the event needs to be invoked after
    /// OnGameSessionEnded
    /// </summary>
    public UnityEvent<int> OnGameSessionEndedUI; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StopTimeScale()
    {
        Time.timeScale = 0;
    }

    public void StartTimeScale()
    {
        Time.timeScale = 1;
    }

   
}
