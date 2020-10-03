using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public GameObject DialogBubblePrefab;
    public float messageHeight = 2f;

    public int health = 3;
    public bool isSaved = false;
    public bool isKilled = false;

    public string answerThatKilledMe = "";
    public string answerThatSavedMe = "";

    // Start is called before the first frame update
    public Riddle riddle = null;
    List<string> hints = new List<string>();

    float hintReleaseDelay = 1f;
    float hintReleaseTimer;

    DialogBubbleController currentDialogBubble = null;


    bool isNearPlayer = false;
    private void Awake()
    {
        hintReleaseTimer = hintReleaseDelay;

        riddle = Riddles.EasyRiddles[0];
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

            if (isNearPlayer)
            {
                Debug.Log("player is near!!!");
            }

            ShowRandomHint();
        }
    }

    public void ShowRandomHint()
    {
        if (hints.Count == 0)
        {
            hints = riddle.GetAllHints();
        }

        if (currentDialogBubble == null || currentDialogBubble.isFading)
        {

            if (hints.Count > 0)
            {
                DialogBubbleController dialogBubble = Instantiate(DialogBubblePrefab, new Vector3(transform.position.x, transform.position.y + messageHeight, 0), Quaternion.identity).GetComponent<DialogBubbleController>();
                int removeIndex = Random.Range(0, hints.Count);
                dialogBubble.ShowMessage(hints[removeIndex]);
                hints.RemoveAt(removeIndex);

                currentDialogBubble = dialogBubble;
            }
        }
        else
        {
            hintReleaseTimer = 0.2f;
        }


    }

    public void OnPlayerInteract()
    {
        if (isSaved)
        {
            if(currentDialogBubble == null || currentDialogBubble.isFading)
            {
                DialogBubbleController dialogBubble = Instantiate(DialogBubblePrefab, new Vector3(transform.position.x, transform.position.y + messageHeight, 0), Quaternion.identity).GetComponent<DialogBubbleController>();
                dialogBubble.ShowMessage(Responses.GetRandomThanks(answerThatSavedMe), 0.08f, 0.45f);

                currentDialogBubble = dialogBubble;
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
                if(currentDialogBubble != null)
                {
                    currentDialogBubble.ForceFadeMessage();
                }

                DialogBubbleController dialogBubble = Instantiate(DialogBubblePrefab, new Vector3(transform.position.x, transform.position.y + messageHeight, 0), Quaternion.identity).GetComponent<DialogBubbleController>();
                dialogBubble.ShowMessage($"...{answer}... that sounds familiar... hey, that's it! Thank you!", 0.1f);
                currentDialogBubble = dialogBubble;

                answerThatSavedMe = answer;
                Responses.AddThanks(answerThatSavedMe);
            }
            else
            {
                health -= 1;

                if (health <= 0)
                {
                    isKilled = true;
                    answerThatKilledMe = answer;
                    Debug.Log($"YOU KILLED ME with the answer: {answerThatKilledMe}");
                }
            }
        }
    }


    public void AssignRiddle(Riddle riddle)
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
            player.Interacted.AddListener(OnPlayerInteract);
        }
    }
}

public static class Responses
{
    public readonly static List<string> Thanks = new List<string>()
    {
        "Thank you so much for saving me!",
        "You saved me!!!",
        "I don't know what was wrong with me...",
        "I love you!",
        "You're a genius!",
        "How did you know what I was babbling about...",
        "My mind was in such a loop...",
        "I love life!!!",

    };

    public static void AddThanks(string correctAnswer)
    {
        Thanks.AddRange(new List<string>()
        {
            $"{correctAnswer}... {correctAnswer}... {correctAnswer}!!! I remember!!!",
            $"do you ever just think about... {correctAnswer}",
        });
    }

    public static string GetRandomThanks(string correctAnswer)
    {
        return Thanks[Random.Range(0, Thanks.Count)];
    }
}