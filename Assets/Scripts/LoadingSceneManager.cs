using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingSceneManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI randomText_text;
    [SerializeField] private float loadingSceneDelay = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisplayRandomLoadingText();
       StartCoroutine( LoadNextScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayRandomLoadingText()
    {
        randomText_text.text = "random";
    }

    private System.Collections.IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(loadingSceneDelay);

        StartCoroutine(SceneLoader.Instance.LoadSceneInAsync(
            PlayerPrefsManager.Instance.GetNextSceneToLoad()));
    }
}
