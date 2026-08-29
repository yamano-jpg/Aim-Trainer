using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageSettings : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider seSlider;
    public TextMeshProUGUI bgmValueText;
    public TextMeshProUGUI seValueText;

    private AudioSource bgmSource;

    void Start()
    {
        bgmSource = FindAnyObjectByType<AudioSource>();

        // MenuSettings の値でスライダーを初期化
        if (bgmSlider != null)
        {
            bgmSlider.value = MenuSettings.bgmVolume;
            bgmSlider.onValueChanged.AddListener(OnBGMChanged);
        }
        if (seSlider != null)
        {
            seSlider.value = MenuSettings.seVolume;
            seSlider.onValueChanged.AddListener(OnSEChanged);
        }

        UpdateTexts();
    }

    void OnBGMChanged(float value)
    {
        MenuSettings.bgmVolume = value;
        if (bgmSource != null) bgmSource.volume = value;
        UpdateTexts();
    }

    void OnSEChanged(float value)
    {
        MenuSettings.seVolume = value;
        UpdateTexts();
    }

    void UpdateTexts()
    {
        if (bgmValueText != null)
            bgmValueText.text = MenuSettings.bgmVolume.ToString("F2");
        if (seValueText != null)
            seValueText.text = MenuSettings.seVolume.ToString("F2");
    }
}