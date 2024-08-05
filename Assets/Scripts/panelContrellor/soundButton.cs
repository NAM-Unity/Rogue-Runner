using UnityEngine;
using UnityEngine.UI;

public class soundButton : MonoBehaviour
{
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public AudioSource audioSource;

    private bool isSoundOn = true;
    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        UpdateButtonImage();
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        if (isSoundOn)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
        UpdateButtonImage();
    }

    void UpdateButtonImage()
    {
        if (isSoundOn)
        {
            buttonImage.sprite = soundOnSprite;
        }
        else
        {
            buttonImage.sprite = soundOffSprite;
        }
    }
}
