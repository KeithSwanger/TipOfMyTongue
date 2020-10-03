using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInputBox : MonoBehaviour
{
    public Canvas canvas;
    public CanvasGroup canvasGroup;

    [SerializeField]
    private TMP_Text text;

    bool showInput = false;

    void Awake()
    {
        canvasGroup.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (showInput)
        {
            if(canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += 5 * Time.deltaTime;
            }
        }
        else
        {
            if(canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= 5 * Time.deltaTime;
            }
        }
        
    }

    public void HidePlayerInput()
    {
        showInput = false;
    }

    public void ShowPlayerInput()
    {
        text.text = "start typing...";
        text.alpha = 0.5f;
        text.fontStyle = FontStyles.Italic;
        showInput = true;
    }


    public void AddCharacter(char c)
    {
        if(text.fontStyle == FontStyles.Italic)
        {
            text.fontStyle = FontStyles.Normal;
            text.alpha = 1f;
            text.text = "";
        }


        if (text.text.Length < 15 && Char.IsLetterOrDigit(c))
        {
            text.text += c;
        }
    }

    public void RemoveCharacter()
    {
        if (text.fontStyle != FontStyles.Italic && text.text.Length > 0)
        {
            text.text = text.text.Substring(0, text.text.Length - 1);
        }
    }

    public string GetPlayerInput()
    {
        if(text.fontStyle != FontStyles.Italic && text.text.Length > 0)
        {
            return text.text;
        }
        else
        {
            return String.Empty;
        }
    }
}
