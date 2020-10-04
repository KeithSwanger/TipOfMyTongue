using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogBubbleController : MonoBehaviour
{
    public UnityEvent LetterDisplayedEvent;
    public AudioClip textSound;
    SoundMananger soundManager;

    public CanvasGroup canvasGroup;
    public TMP_Text text;

    public float charDelay = 0.05f;
    public float charDelayTimer;

    public int charPos = 0;

    public string targetText = null;

    public bool canDelete = false;
    public bool isFading = false;
    bool fadeAway = false;
    float fadeDelay = 0.35f;
    float fadeDelayTimer;

    Vector2 fadeDirection;

    public bool isFullMessageVisible = false;

    void Awake()
    {
        soundManager = SoundMananger.instance;
        text.text = "";
        canvasGroup.alpha = 1f;
    }


    public void ShowMessage(string message, float charDelay = 0.05f, float fadeDelay = 0.1f, float alpha = 1, bool isItalicized = false, bool randomizeFadeDirection = true) 
    {
        canDelete = false;
        this.charDelay = charDelay;
        this.fadeDelay = fadeDelay;
        isFading = false;
        fadeDelayTimer = fadeDelay;
        fadeAway = false;
        text.text = "";
        targetText = message;
        charDelayTimer = charDelay;
        canvasGroup.alpha = alpha;
        isFullMessageVisible = false;


        if (isItalicized)
        {
            text.fontStyle = FontStyles.Italic;
        }

        // randomize fade direction
        if(randomizeFadeDirection)
        {
        fadeDirection = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        }
        else
        {
            fadeDirection = new Vector2(0f, 2f);
        }
    }

    public void ForceFadeMessage()
    {
        if(canvasGroup.alpha > 0.5f)
        {   
            canvasGroup.alpha = 0.5f;
        }
        fadeAway = true;
        isFading = true;
    }

    public void ForceShowFullMessage()
    {
        charPos = targetText.Length;
        text.text = targetText;
        isFullMessageVisible = true;
        LetterDisplayedEvent.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
        if (fadeAway)
        {
            canvasGroup.alpha -= Time.deltaTime;
            transform.position = new Vector2(transform.position.x + fadeDirection.x * Time.deltaTime, transform.position.y + fadeDirection.y * Time.deltaTime);

            if (canvasGroup.alpha <= 0f)
            {
                 GameObject.Destroy(this.gameObject);
            }

        }
        else if (targetText != null && charPos < targetText.Length)
        {
            charDelayTimer -= Time.deltaTime;

            if (charDelayTimer <= 0)
            {
                charDelayTimer = charDelay;

                text.text += targetText[charPos];
                charPos++;

                LetterDisplayedEvent.Invoke();

                if(text.text == targetText)
                {
                    isFullMessageVisible = true;
                }
            }
        }
        else
        {
            fadeDelayTimer -= Time.deltaTime;
            if (fadeDelayTimer <= 0f)
            {
                isFading = true;
                fadeAway = true;
            }
        }

    }
}
