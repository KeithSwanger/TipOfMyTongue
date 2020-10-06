﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Citizen : MonoBehaviour
{
    public SortSpriteOnUpdate spriteSorter;
    public SpriteAnimator idleAnimation;
    public SpriteAnimator deathAnimation;

    float baseAudioPitch;
    public AudioClip letterSoundHectic;
    public AudioClip letterSoundDead;
    public AudioClip letterSoundThankful;

    public AudioClip deathSoundEffect;
    SoundMananger soundMananger;
    Responses responses = new Responses();
    public GameObject DialogBubblePrefab;
    public float messageHeight = 2f;

    public int health = 3;
    public bool isSaved = false;
    public bool isKilled = false;

    public CitizenDiedEvent DiedEvent = new CitizenDiedEvent();
    public CitizenSavedEvent SavedEvent = new CitizenSavedEvent();

    public string answerThatKilledMe = "";
    public string answerThatSavedMe = "";

    private string previousHint = null;

    // Start is called before the first frame update
    public Riddle riddle = null;
    List<string> hints = new List<string>();

    float hintReleaseDelay = 1f;
    float hintReleaseTimer;


    DialogBubbleController currentDialogBubble = null;


    bool isNearPlayer = false;
    private void Awake()
    {
        DiedEvent.AddListener(OnDeath);
        baseAudioPitch = Random.Range(0.6f, 1.7f);
        soundMananger = SoundMananger.instance;
        hintReleaseTimer = hintReleaseDelay + Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (riddle != null && !isSaved && !isKilled)
        {
            UpdateRiddle();
        }
    }


    void UpdateRiddle()
    {
        hintReleaseTimer -= Time.deltaTime;

        if (hintReleaseTimer <= 0f)
        {
            hintReleaseTimer = hintReleaseDelay; // Reset timer

            ShowRandomHint();
        }
    }


    private void OnLetterDisplayed()
    {
        if (isNearPlayer)
        {
            if (isSaved)
            {
                soundMananger.PlaySoundEffect(letterSoundThankful, soundMananger.soundVolume, currentDialogBubble.transform.position, baseAudioPitch + Random.Range(-0.3f, 0.3f));

            }
            else if (isKilled)
            {
                soundMananger.PlaySoundEffect(letterSoundDead, soundMananger.soundVolume, currentDialogBubble.transform.position, baseAudioPitch + Random.Range(-0.3f, 0.3f));

            }
            else
            {
                soundMananger.PlaySoundEffect(letterSoundHectic, soundMananger.soundVolume, currentDialogBubble.transform.position, baseAudioPitch + Random.Range(-0.3f, 0.3f));
            }
        }
    }

    public void ShowRandomHint()
    {
        if (hints.Count == 0)
        {
            hints = riddle.GetAllHints();
            hints.Remove(previousHint);
        }

        if (hints.Count == 1 && hints[0] == previousHint)
        {
            hints = riddle.GetAllHints();
            hints.Remove(previousHint);
        }


        if (currentDialogBubble == null || currentDialogBubble.isFading)
        {

            if (hints.Count > 0)
            {
                int removeIndex = Random.Range(0, hints.Count);
                CreateDialogBubble(hints[removeIndex], 0.05f, 0.0f, 1f, false, true);
                previousHint = hints[removeIndex];
                hints.RemoveAt(removeIndex);

            }
        }
        else
        {
            hintReleaseTimer = 0.1f;
        }


    }

    void OnDeath(Citizen c)
    {
        soundMananger.ForcePlaySoundEffect(deathSoundEffect, soundMananger.soundVolume, transform.position, Random.Range(0.75f, 1.2f));

        idleAnimation.Stop();
        deathAnimation.PlayOnce();
        spriteSorter.offset += 2;
    }

    public void OnPlayerInteract()
    {
        if (currentDialogBubble == null || currentDialogBubble.isFading)
        {
            if (isSaved)
            {
                CreateDialogBubble(responses.GetRandomThanks(), 0.08f, 0.45f, 1f, false, false);
            }
            else if (isKilled)
            {
                CreateDialogBubble(responses.GetRandomWrongResponse(), 0.1f, 0.5f, 0.55f, true, false);

            }
        }
    }

    public void OnPlayerSubmittedAnswer(string answer)
    {
        if (!isKilled && !isSaved)
        {
            if (riddle.TryAnswer(answer))
            {
                // Riddle correct! Let's do something!
                isSaved = true;
                if (currentDialogBubble != null)
                {
                    currentDialogBubble.ForceFadeMessage();
                }

                answerThatSavedMe = answer;
                responses.AddCorrectAnswerToResponses(answerThatSavedMe);

                CreateDialogBubble(responses.GetRandomCorrectAnswerResponse(), 0.1f, 0.35f, 1, false, false);

                SavedEvent.Invoke(this);

            }
            else
            {
                health -= 1;

                if (health <= 0)
                {
                    isKilled = true;
                    answerThatKilledMe = answer;
                    responses.AddWrongAnswerToResponses(answerThatKilledMe);

                    if (currentDialogBubble != null)
                    {
                        currentDialogBubble.ForceFadeMessage();
                    }

                    DiedEvent.Invoke(this);
                }
            }
        }
    }

    public void CreateDialogBubble(string message, float charDelay = 0.05f, float fadeDelay = 0.35f, float alpha = 1f, bool isItalicized = false, bool randomizeDirection = true)
    {
        DialogBubbleController dialogBubble = Instantiate(DialogBubblePrefab, new Vector3(transform.position.x, transform.position.y + messageHeight, 0), Quaternion.identity).GetComponent<DialogBubbleController>();
        dialogBubble.ShowMessage(message, charDelay, fadeDelay, alpha, isItalicized, randomizeDirection);
        currentDialogBubble = dialogBubble;

        currentDialogBubble.LetterDisplayedEvent.AddListener(OnLetterDisplayed);
    }


    public void SetRiddle(Riddle riddle)
    {
        this.riddle = riddle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerInteraction>()?.player;
        if (player != null)
        {
            isNearPlayer = true;
            player.Interacted.AddListener(OnPlayerInteract);
            player.AnswerSubmitted.AddListener(OnPlayerSubmittedAnswer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerInteraction>()?.player;
        if (player != null)
        {
            isNearPlayer = false;
            player.Interacted.RemoveListener(OnPlayerInteract);
            player.AnswerSubmitted.RemoveListener(OnPlayerSubmittedAnswer);
        }
    }
}

public class CitizenDiedEvent : UnityEvent<Citizen>
{
}

public class CitizenSavedEvent : UnityEvent<Citizen>
{
}

public class Responses
{
    public List<string> Thanks = new List<string>()
    {
        "Thank you so much for saving me!",
        "You saved me!!!",
        "I don't know what was wrong with me...",
        "I love you!",
        "You're a genius!",
        "How did you know what I was babbling about...",
        "My mind was in such a loop...",
        "I love life!!!"
    };

    private List<string> CorrectAnswerResponses = new List<string>();
    private List<string> WrongAnswerResponses = new List<string>();

    public void AddCorrectAnswerToResponses(string correctAnswer)
    {
        AddThanks(correctAnswer);

        CorrectAnswerResponses.AddRange(new List<string>()
        {
            $"...{correctAnswer}... that sounds familiar... hey, you saved me! Thank you!",
            $"{correctAnswer}!!! That's it!!! Thank you!!!",
            $"{correctAnswer}!!! That's the word I was looking for! You're so smart!!!",
            $"{correctAnswer}!!! How could I have forgot... Thank you!",
            $"{correctAnswer}... no that's not it... wait... {correctAnswer}... that is it! Thank you!",
            $"{correctAnswer}... heh, must have slipped my mind. Thanks, bud",
            $"How could I have forgotten {correctAnswer}... thanks!",
        });
    }

    public void AddWrongAnswerToResponses(string wrongAnswer)
    {
        WrongAnswerResponses.AddRange(new List<string>()
        {
            $"{wrongAnswer}... that was not it...",
            $"...you did this...",
            $"...why did you do this to me...",
            "I had a family",
            $"{wrongAnswer}... was that the best you could think of..."
        });
    }




    public void AddThanks(string correctAnswer)
    {
        Thanks.AddRange(new List<string>()
        {
            $"{correctAnswer}... {correctAnswer}... {correctAnswer}!!! I remember!!!",
            $"do you ever just think about... {correctAnswer}... beautiful",
            $"just saying '{correctAnswer}' cures brain eating viruses... who knew... thanks again!",
        });
    }

    public string GetRandomCorrectAnswerResponse()
    {
        return CorrectAnswerResponses[Random.Range(0, CorrectAnswerResponses.Count)];
    }
    public string GetRandomThanks()
    {
        return Thanks[Random.Range(0, Thanks.Count)];
    }
    public string GetRandomWrongResponse()
    {
        return WrongAnswerResponses[Random.Range(0, WrongAnswerResponses.Count)];
    }
}