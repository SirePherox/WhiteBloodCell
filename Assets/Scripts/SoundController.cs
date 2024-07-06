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
    [Space]
    [SerializeField] private AudioClip mainMenu;

    [Header("Variables")]
    private float sfxVolume;
    private float musicVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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
    #endregion

    #region -Attack Sounds-
    public void PlayKillAttack()
    {
        PlaySFXEffects(killAttack, true);
    }

    public void PlayEngulfAttack()
    {
        PlaySFXEffects(engulfAttack, false);
    }
    #endregion

    private void PlayMusic(AudioClip clip)
    {
        musicSource.Stop();
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.clip = clip;
        musicSource.Play();
    }

    private void PlaySFXEffects(AudioClip clip, bool isLoop)
    {
        sfxSource.Stop();
        sfxSource.loop = isLoop;
        sfxSource.volume = sfxVolume;
        sfxSource.PlayOneShot(clip);
    }


}
