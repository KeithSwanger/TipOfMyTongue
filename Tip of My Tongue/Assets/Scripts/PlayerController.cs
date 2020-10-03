using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public UnityEvent Interacted = new UnityEvent();

    [HideInInspector]
    public Rigidbody2D rb;

    public Citizen citizenInteractingWith = null;

    IPlayerState playerState;

    public int moveSpeed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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

        // Should I do state execute here ? probably not

    }

    private void Update()
    {
        if (playerState != null)
        {
            playerState.Execute();
        }
    }

}
