using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public GameMananger gameMananger;
    public UnityEvent Interacted = new UnityEvent();
    public StringSubmittedEvent AnswerSubmitted = new StringSubmittedEvent();

    public PlayerInputBox playerInputBox;

    public SpriteAnimator idleAnimation;
    public SpriteAnimator walkAnimation;

    [HideInInspector]
    public Rigidbody2D rb;

    public Citizen citizenInteractingWith = null;

    IPlayerState playerState;

    public int moveSpeed = 10;

    private void Awake()
    {
        gameMananger = GameMananger.instance;
        rb = GetComponent<Rigidbody2D>();
        playerInputBox = GetComponent<PlayerInputBox>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SwitchState(new PlayerState_Move(this));
    }

    public void StartWalkAnimation()
    {
        idleAnimation.Stop();
        walkAnimation.Play();
    }

    public void StartIdleAnimation()
    {
        walkAnimation.Stop();
        idleAnimation.Play();
    }

    public void LockPlayerToInteraction()
    {
        SwitchState(new PlayerState_LockedInteraction(this));
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

    public void UnlockPlayer()
    {
        SwitchState(new PlayerState_Move(this));
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
