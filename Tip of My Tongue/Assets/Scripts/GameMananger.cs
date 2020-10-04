using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananger : MonoBehaviour
{ 
    public AudioClip backgroundMusic;
    SoundMananger soundMananger;

    public CitizenManager citizenManager;
    public EndScreenController endScreenController;

    public bool isGameComplete = false;



    private void Awake()
    {
        soundMananger = SoundMananger.instance;

        citizenManager.AllCitizensInteractedWithEvent.AddListener(OnAllCitizensInteractedWith);

        citizenManager.ApplyAllRiddles();
    }
    void Start()
    {
        if (!soundMananger.isPlayingMusic)
        {
            soundMananger.PlayMusic(backgroundMusic, soundMananger.musicVolume);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            endScreenController.ShowEndScreen(new GameResult(24, 0, 910, 830));
        }
    }

    void OnAllCitizensInteractedWith()
    {
        isGameComplete = true;

        endScreenController.ShowEndScreen(citizenManager.GetGameResults());
    }
}
