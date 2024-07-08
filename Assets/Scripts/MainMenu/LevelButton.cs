using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelSelectorManager lvlSelector;
    [SerializeField] private Button levelButton;
    [Space]
    [SerializeField] private int levelNumb;

    private void Awake()
    {
        levelButton = GetComponent<Button>();
        levelButton.interactable = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lvlSelector = FindAnyObjectByType<LevelSelectorManager>();
        levelButton.onClick.AddListener(SelectLevel);
        CheckLevelAccess();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectLevel()
    {
        lvlSelector.UpdateSceneBasedOnLevelSelected(levelNumb);
    }


    private void CheckLevelAccess()
    {
        int unlockableLevel = PlayerPrefsManager.Instance.GetLevelCompletedNumber() + 1;
        if(unlockableLevel >= levelNumb)
        {
            levelButton.interactable = true;
        }
    }
}
