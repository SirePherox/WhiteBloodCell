using UnityEngine;
using UnityEngine.UI;

public class SoundSliderManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image targetImage;
    [SerializeField] private Sprite normalImageSprite;
    [SerializeField] private Sprite disactivatedImageSprite;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public enum SoundSliderType
    {
        Music,
        SFX
    }

    public SoundSliderType soundType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.onValueChanged.AddListener( OnSliderValueChanged);

        //get soundbased on saved preferences
        if(soundType == SoundSliderType.Music)
        {
            slider.value = PlayerPrefsManager.Instance.GetSoundSliderVolume(PlayerPrefsNames.MUSIC_SLIDER);
        }
        else
        {
            slider.value = PlayerPrefsManager.Instance.GetSoundSliderVolume(PlayerPrefsNames.SFX_SLIDER);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSliderValueChanged(float newValue)
    {
        if(newValue <= 0.01f)
        {
            //disactiovated
            targetImage.sprite = disactivatedImageSprite;
        }
        else
        {
            targetImage.sprite = normalImageSprite;
        }

        //save value to preference
        if (soundType == SoundSliderType.Music)
        {
            PlayerPrefsManager.Instance.SetSoundSliderVolume(PlayerPrefsNames.MUSIC_SLIDER, newValue);
        }
        else
        {
            PlayerPrefsManager.Instance.SetSoundSliderVolume(PlayerPrefsNames.SFX_SLIDER, newValue);
        }
        Debug.Log(newValue);

    }
}
