using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public string mainSceneName;


    public AudioClip music;
    SoundMananger soundManager;

    private void Awake()
    {
        soundManager = SoundMananger.instance;
        if(!soundManager.isPlayingMusic)
        { 
            soundManager.PlayMusic(music, soundManager.musicVolume);
        }
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
