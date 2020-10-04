using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenuController : MonoBehaviour
{
    public CanvasGroup escapeMenuCanvasGroup;

    public Slider musicSlider;
    public Slider soundSlider;

    SoundMananger soundMananger;

    bool showEscapeMenu = false;

    private void Awake()
    {
        soundMananger = SoundMananger.instance;
        musicSlider.value = soundMananger.musicVolume;
        soundSlider.value = soundMananger.soundVolume;

        musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        soundSlider.onValueChanged.AddListener(OnSoundVolumeChanged);

        if (showEscapeMenu == false)
        {
            escapeMenuCanvasGroup.gameObject.SetActive(false);
        }
    }

    private void OnMusicVolumeChanged(float newValue)
    {
        soundMananger.musicVolume = newValue;
    }

    private void OnSoundVolumeChanged(float newValue)
    {
        soundMananger.soundVolume = newValue;
    }


    private void Update()
    {
        if (showEscapeMenu)
        {
            if(escapeMenuCanvasGroup.alpha < 1f)
            {
                escapeMenuCanvasGroup.alpha += Time.deltaTime;
            }
        }
    }
    public void OpenEscapeMenu()
    {
        showEscapeMenu = true;
        escapeMenuCanvasGroup.alpha = 0f;

        escapeMenuCanvasGroup.gameObject.SetActive(true);

    }

    public void CloseEscapeMenu()
    {
        showEscapeMenu = false;
        escapeMenuCanvasGroup.alpha = 0f;

        escapeMenuCanvasGroup.gameObject.SetActive(false);
    }

}
