using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public UnityEvent Interacted = new UnityEvent();
    public StringSubmittedEvent AnswerSubmitted = new StringSubmittedEvent();

    public PlayerInputBox playerInputBox;

    [HideInInspector]
    public Rigidbody2D rb;

    public Citizen citizenInteractingWith = null;

    IPlayerState playerState;

    public int moveSpeed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInputBox = GetComponent<PlayerInputBox>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SwitchState(new PlayerState_Move(this));
    }


    public void SwitchState(IPlayerState newState)
    {
        if(this.playerState != null)
        {
            this.playerState.Exit();
        }

        this.playerState = newState;

        if(this.playerState != null)
        {
            this.playerState.Enter();
        }


    }

    private void Update()
    {
        if (playerState != null)
        {
            playerState.Execute();
        }
    }


    public class StringSubmittedEvent : UnityEvent<string>
    {
    }
}
