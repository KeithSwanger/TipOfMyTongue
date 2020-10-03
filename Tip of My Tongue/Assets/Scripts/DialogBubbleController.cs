using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBubbleController : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public TMP_Text text;

    public float charDelay = 0.05f;
    public float charDelayTimer;

    public int charPos = 0;

    public string targetText = null;

    public bool isFading = false;
    bool fadeAway = false;
    float fadeDelay = 0.35f;
    float fadeDelayTimer;


    void Awake()
    {
        text.text = "";
        canvasGroup.alpha = 1f;
    }


    public void ShowMessage(string message, float charDelay = 0.05f, float fadeDelay = 0.35f)
    {
        this.charDelay = charDelay;
        this.fadeDelay = fadeDelay;
        isFading = false;
        fadeDelayTimer = fadeDelay;
        fadeAway = false;
        text.text = "";
        targetText = message;
        charDelayTimer = charDelay;
        canvasGroup.alpha = 1f;
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


    // Update is called once per frame
    void Update()
    {
        if (fadeAway)
        {
            canvasGroup.alpha -= Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y + (2 * Time.deltaTime));

            if (canvasGroup.alpha <= 0f)
            {
                GameObject.Destroy(this);
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
