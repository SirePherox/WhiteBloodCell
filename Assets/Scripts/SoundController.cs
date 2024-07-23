using UnityEngine;

public class SoundController : SingletonCreator<SoundController>
{
    [Header("References")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip killAttack;
    [SerializeField] private AudioClip engulfAttack;
    [SerializeField] private AudioClip weakenAttack;
    [SerializeField] private AudioClip threatHit;
    [SerializeField] private AudioClip playerHurt;

    [Space]
    [SerializeField] private AudioClip mainMenu;
    [SerializeField] private AudioClip loadingScene;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
    #region -UI Sounds-
    public void PlayButtonClick()
    {
        PlaySFXEffects(buttonClick, false);
    }

    public void PlayMainMenuBGMusic()
    {
        PlayMusic(mainMenu);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
    }

    public void PlayLoadingSceneMusic()
    {
        PlayMusic(loadingScene);
    }
    #endregion

    #region -Attack Sounds-
    public void PlayPlayerHurt()
    {
        PlaySFXEffects(playerHurt, false);
    }
    public void PlayThreatHurt()
    {
        PlaySFXEffects(threatHit, false);
    }
    public void PlayKillAttack()
    {
        PlaySFXEffects(killAttack, true);
    }

    public void PlayEngulfAttack()
    {
        PlaySFXEffects(engulfAttack, false);
    }

    public void PlayNeutralAttack()
    {
        sfxSource.loop = false;
        sfxSource.Stop();
        
    }

    public void PlayWeakenAttack()
    {
        PlaySFXEffects(weakenAttack, false);
    }

    #endregion

    private void PlayMusic(AudioClip clip)
    {
        musicSource.Stop();
        musicSource.loop = true;
        musicSource.volume = PlayerPrefsManager.Instance.GetSoundSliderVolume(PlayerPrefsNames.MUSIC_SLIDER);
        musicSource.clip = clip;
        musicSource.Play();
    }

    private void PlaySFXEffects(AudioClip clip, bool isLoop)
    {
        sfxSource.Stop();
        sfxSource.loop = isLoop;
        sfxSource.volume = PlayerPrefsManager.Instance.GetSoundSliderVolume(PlayerPrefsNames.SFX_SLIDER); ;
        if (isLoop)
        {
            sfxSource.clip = clip;
            sfxSource.Play();
        }
        else
        {
            sfxSource.PlayOneShot(clip);
        }
        
    }


}
