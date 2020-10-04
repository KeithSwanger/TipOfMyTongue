using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    private static GameMananger _instance;
    public static GameMananger instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMananger>();
            }

            return _instance;
        }
    }

    public AudioClip backgroundMusic;
    SoundMananger soundMananger;

    public CitizenManager citizenManager;
    public EndScreenController endScreenController;
    public EscapeMenuController escapeMenu;

    public bool isGameComplete { get; set; } = false;



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

    public void EndGame()
    {
        this.endScreenController.ShowEndScreen(citizenManager.GetGameResults());
    }

    void OnAllCitizensInteractedWith()
    {
        isGameComplete = true;

        //endScreenController.ShowEndScreen(citizenManager.GetGameResults());
    }
}
