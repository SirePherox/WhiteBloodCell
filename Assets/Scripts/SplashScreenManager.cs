using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private float loadingSceneDelay;
    [SerializeField] private Slider loadingSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadSceneWithSliderUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadSceneWithSliderUpdate()
    {
        float timeElapsed = 0f;
        while (timeElapsed < loadingSceneDelay)
        {
            // Update slider value based on elapsed time
            loadingSlider.value = Mathf.Clamp01(timeElapsed / loadingSceneDelay);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(SceneIndex.mainMenu);
    }
}
