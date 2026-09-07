using UnityEngine;

public class UISound : MonoBehaviour
{
    public AudioClip clickSound;

    public void PlayClick()
    {
        if (clickSound != null)
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position, MenuSettings.seVolume);
    }
}