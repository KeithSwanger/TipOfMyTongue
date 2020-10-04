using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConcernedCitizen : MonoBehaviour
{
    GameMananger gameMananger;
    public GameObject DialogBubblePrefab;
    public float messageHeight = 2f;
    DialogBubbleController currentDialogBubble = null;

    public UnityEvent InitialConversationOver = new UnityEvent();
    public bool isFirstInteraction = true;

    public UnityEvent EndingConversationOver = new UnityEvent();
    public bool isEndingConversation = false;

    bool showHelpMessage = true;
    float helpMessageDelay = 3f;
    float helpMessageTimer;

    List<string> helpMessages = new List<string>()
    {
        "help!",
        "somebody!",
        "please somebody help",
        "help!!!",
        "can someone please help",
    };

    int introDialogIndex = 0;
    List<string> introDialog = new List<string>()
    {
        "Help! I think there's something in the water!",
        "People here are forgetting words, and it's driving them crazy!",
        "Their minds are stuck in a loop, trying to find the word they forgot",
        "Something has infected their brains. Please help them!",
        "Listen to them, and speak the word they are trying to remember!",
        "Be careful though, I'm afraid something terrible could happen if you're wrong!",
        "Come back here when you're done!"
    };

    int endingDialogIndex = 0;
    List<string> endingDialog = new List<string>()
    {
        "I think that's everyone!",
        "You saved them all!",
        ".........Didn't you.........",
        "Who am I kidding, of course you did!",
        "You wouldn't go yell out words unless you were completely sure",
        "Especially after I warned you that terrible things could happen",
        "no, you wouldn't do that",
        "We're so lucky that you happened to walk by when disaster struck",
        "A person of knowledge",
        "A person of courage",
        "A genius!!!",
        "Everyone here is so grateful!",
        "Alive and grateful",
        "And definitely alive",
        "Thank you so much!",
        "Goodbye!!!!!!!!!!!!!!!!!!!!!!!!!"
    };

    List<string> midGameMessages = new List<string>()
    {
        "Come back to me when you save everyone!",
        "Good luck!",
        "Have you ever been to the... uhh... the... what was that called again... hah, just kidding",
        "Talk to everyone before coming back here",
        "What are they talking about...",
        "How could anyone forget such an easy word...",
        ""
    };

    float baseAudioPitch = 1f;
    public AudioClip letterSound;

    SoundMananger soundMananger;


    private void Awake()
    {
        gameMananger = GameMananger.instance;
        baseAudioPitch = Random.Range(0.9f, 1.3f);
        soundMananger = SoundMananger.instance;
    }

    // Update is called once per frame
    void Update()
    {

        if (showHelpMessage)
        {
            UpdateHelpMessage();
        }
    }

    void UpdateHelpMessage()
    {
        helpMessageTimer -= Time.deltaTime;

        if (helpMessageTimer <= 0f)
        {
            helpMessageTimer = helpMessageDelay; // Reset timer

            ShowRandomHelp();
        }
    }

    void ShowRandomHelp()
    {
        if (currentDialogBubble == null || currentDialogBubble.isFading)
        {
            CreateDialogBubble(helpMessages[Random.Range(0, helpMessages.Count)], 0.05f, 0.1f, 1f, false, true);
        }
    }

    void ShowRandomMidGameMessage()
    {
        if (currentDialogBubble == null || currentDialogBubble.isFading)
        {
            CreateDialogBubble(midGameMessages[Random.Range(0, midGameMessages.Count)], 0.08f, 0.2f, 1f, false, false);
        }
    }


    public void CreateDialogBubble(string message, float charDelay = 0.05f, float fadeDelay = 0.35f, float alpha = 1f, bool isItalicized = false, bool randomizeDirection = true)
    {
        DialogBubbleController dialogBubble = Instantiate(DialogBubblePrefab, new Vector3(transform.position.x, transform.position.y + messageHeight, 0), Quaternion.identity).GetComponent<DialogBubbleController>();
        dialogBubble.ShowMessage(message, charDelay, fadeDelay, alpha, isItalicized, randomizeDirection);
        currentDialogBubble = dialogBubble;

        currentDialogBubble.LetterDisplayedEvent.AddListener(OnLetterDisplayed);
    }

    private void OnLetterDisplayed()
    {
        soundMananger.PlaySoundEffect(letterSound, soundMananger.soundVolume, currentDialogBubble.transform.position, baseAudioPitch + Random.Range(-0.3f, 0.3f));

    }

    public void OnPlayerInteract()
    {
        if (isFirstInteraction)
        {
            if (introDialogIndex < introDialog.Count)
            {
                if (currentDialogBubble != null)
                {
                    if (currentDialogBubble.isFullMessageVisible)
                    {
                        currentDialogBubble.ForceFadeMessage();
                    }
                    else
                    {
                        currentDialogBubble.ForceShowFullMessage();
                    }
                }

                if (currentDialogBubble == null || currentDialogBubble.isFading)
                {
                    if (introDialogIndex == introDialog.Count - 1)
                    {
                        CreateDialogBubble(introDialog[introDialogIndex], 0.07f, 3f, 1f, false, false);
                    }
                    else
                    {
                        CreateDialogBubble(introDialog[introDialogIndex], 0.07f, 100f, 1f, false, false);
                    }

                    introDialogIndex++;
                    if (introDialogIndex >= introDialog.Count)
                    {
                        // intro over, unlock player
                        isFirstInteraction = false;
                        InitialConversationOver.Invoke();
                    }
                }
            }
        }
        else if (isEndingConversation)
        {
            if (endingDialogIndex < endingDialog.Count)
            {
                if (currentDialogBubble != null)
                {
                    if (currentDialogBubble.isFullMessageVisible)
                    {
                        currentDialogBubble.ForceFadeMessage();
                    }
                    else
                    {
                        currentDialogBubble.ForceShowFullMessage();
                    }
                }

                if (currentDialogBubble == null || currentDialogBubble.isFading)
                {
                    CreateDialogBubble(endingDialog[endingDialogIndex], 0.07f, 100f, 1f, false, false);
                    endingDialogIndex++;
                }
            }
            else
            {
                EndingConversationOver.Invoke();

                EndingConversationOver.RemoveAllListeners();
            }
        }
        else
        {
            ShowRandomMidGameMessage();
        }
    }

    public void StartInitialConversation()
    {
        showHelpMessage = false;
        if (currentDialogBubble != null)
        {
            currentDialogBubble.ForceFadeMessage();
        }

        // Player doesn't need to interact to start the first converstaion
        OnPlayerInteract();
    }

    public void StartEndingConversation()
    {
        isEndingConversation = true;
    }

}
