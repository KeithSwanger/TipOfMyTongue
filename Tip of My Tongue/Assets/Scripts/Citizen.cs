using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    int health = 3;
    bool saved = false;
    bool killed = false;

    // Start is called before the first frame update
    public Riddle riddle = null;
    List<string> hints = new List<string>();

    float hintReleaseTime = 3;
    float hintReleaseTimer;


    bool isNearPlayer = false;
    private void Awake()
    {
        hintReleaseTimer = hintReleaseTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(riddle != null && !saved && !killed)
        {
        }

            UpdateRiddle();
        
    }


    void UpdateRiddle()
    {
        hintReleaseTimer -= Time.deltaTime;

        if (hintReleaseTimer <= 0f)
        {
            hintReleaseTimer = hintReleaseTime; // Reset timer

            if (isNearPlayer)
            {
            Debug.Log("player is near!!!");
            }
            // Release riddle here
        }
    }

    public void OnPlayerInteract()
    {
        Debug.Log("Player interacted!");

        if (saved)
        {

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
