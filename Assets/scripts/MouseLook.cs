using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 0.4f;
    public Slider sensitivitySlider;
    public Transform playerBody;
    public GameObject settingsPanel;
    public TextMeshProUGUI sensValueText;

    float xRotation = 0f;
    float unitySensitivity;
    bool isPaused = false;

    void Start()
    {
        sensitivity = MenuSettings.sensitivity;
        unitySensitivity = sensitivity * 7f;

        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (sensitivitySlider != null)
        {
            sensitivitySlider.value = sensitivity;
            sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        }

        UpdateSensText();
    }

    void OnSensitivityChanged(float value)
    {
        sensitivity = value;
        unitySensitivity = sensitivity * 7f;
        UpdateSensText();
    }

    void UpdateSensText()
    {
        if (sensValueText != null)
            sensValueText.text = sensitivity.ToString("F2");
    }

    void Update()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null && gm.isGameOver) return;
        if (gm != null && !gm.isStarted) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                if (settingsPanel != null)
                    settingsPanel.SetActive(true);
                    if (gm != null) gm.isPaused = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                if (settingsPanel != null)
                    settingsPanel.SetActive(false);
                    if (gm != null) gm.isPaused = false;
            }
        }

        if (!isPaused)
        {
            float mouseX = Input.GetAxis("Mouse X") * unitySensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * unitySensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}