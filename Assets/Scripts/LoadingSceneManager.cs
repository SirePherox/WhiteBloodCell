using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity;
using System.Collections.Generic;

public class LoadingSceneManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private float loadingSceneDelay;
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private List<Sprite> loadingImages;
    [SerializeField] private Image targetImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       UpdateLoadingImage();
       StartCoroutine( LoadSceneWithSliderUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private IEnumerator LoadNextScene()
    //{
    //    yield return new WaitForSeconds(loadingSceneDelay);

    //    StartCoroutine(SceneLoader.Instance.LoadSceneInAsync(
    //        PlayerPrefsManager.Instance.GetNextSceneToLoad()));
    //}

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

        // Scene loading logic (optional)
        yield return StartCoroutine(SceneLoader.Instance.LoadSceneInAsync(
          PlayerPrefsManager.Instance.GetNextSceneToLoad()));
    }

    private void UpdateLoadingImage()
    {
        int randNumb = Random.Range(0, loadingImages.Count - 1);
        targetImage.sprite = loadingImages[randNumb];
    }
}
