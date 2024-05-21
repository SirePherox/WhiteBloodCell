using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image waveDelayUi_img;
    [SerializeField] private Image waveTimer_img;
    public UnityAction<string> OnChangeAttackMechanism;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaveController.Instance.OnWaveStart.AddListener(HideDelayUI);
        WaveController.Instance.OnWaveEnd.AddListener(ShowWaveDelayUI);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void ShowWaveDelayUI(int currentWaveNumb)
    {
        waveDelayUi_img.gameObject.SetActive(true);
        
    }

    private void HideDelayUI(int currentWaveNumb)
    {
        waveDelayUi_img.gameObject.SetActive(false);
        
    }

    private void UpdateUI()
    {
        waveTimer_img.fillAmount = WaveController.Instance.GetWaveTimerRate();
    }

}
