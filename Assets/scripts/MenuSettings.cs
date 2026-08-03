using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuSettings : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider bgmSlider;
    public Slider seSlider;
    public Slider sensSlider;
    public TextMeshProUGUI bgmValueText;
    public TextMeshProUGUI seValueText;
    public TextMeshProUGUI sensValueText;

    public static float bgmVolume = 0.1f;
    public static float seVolume = 0.5f;
    public static float sensitivity = 0.35f;

    void Start()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (bgmSlider != null) bgmSlider.value = bgmVolume;
        if (seSlider != null) seSlider.value = seVolume;
        if (sensSlider != null) sensSlider.value = sensitivity;

        bgmSlider.onValueChanged.AddListener(OnBGMChanged);
        seSlider.onValueChanged.AddListener(OnSEChanged);
        sensSlider.onValueChanged.AddListener(OnSensChanged);

        UpdateAllTexts();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = settingsPanel.activeSelf;
            settingsPanel.SetActive(!isActive);
        }
    }

    void OnBGMChanged(float value)
    {
        bgmVolume = value;
        AudioSource bgm = FindObjectOfType<AudioSource>();
        if (bgm != null) bgm.volume = value;
        if (bgmValueText != null)
            bgmValueText.text = value.ToString("F2");
    }

    void OnSEChanged(float value)
    {
        seVolume = value;
        if (seValueText != null)
            seValueText.text = value.ToString("F2");
    }

    void OnSensChanged(float value)
    {
        sensitivity = value;
        if (sensValueText != null)
            sensValueText.text = value.ToString("F2");
    }

    void UpdateAllTexts()
    {
        if (bgmValueText != null) bgmValueText.text = bgmVolume.ToString("F2");
        if (seValueText != null) seValueText.text = seVolume.ToString("F2");
        if (sensValueText != null) sensValueText.text = sensitivity.ToString("F2");
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}