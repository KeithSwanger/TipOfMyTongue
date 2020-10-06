using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToInteract : MonoBehaviour
{
    public PlayerController player;
    public ConcernedCitizen citizen;

    public CanvasGroup canvasGroup;

    bool deleteGameObect = false;
    bool showMessage = false;

    int interactCounter = 0;

    private void Awake()
    {
        player.Interacted.AddListener(Delete);
        canvasGroup.alpha = 0f;
    }

    private void Update()
    {
        if (deleteGameObect)
        {
            if (canvasGroup.alpha <= 0f)
            {
                GameObject.Destroy(this.gameObject);
            }
            else
            {
                canvasGroup.alpha -= Time.deltaTime;
            }
        }
        else if (showMessage)
        {
            if (canvasGroup.alpha < 1f)
            {
                canvasGroup.alpha += Time.deltaTime;
            }
        }
        else if (!citizen.showHelpMessage)
        {
            showMessage = true;
        }
    }


    void Delete()
    {
        if(!citizen.showHelpMessage)
        {
            interactCounter++;
        }

        if (interactCounter > 1)
        {
            deleteGameObect = true;
            player.Interacted.RemoveListener(Delete);
        }
    }
}
