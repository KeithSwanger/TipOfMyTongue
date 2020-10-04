using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_LockedInteraction : IPlayerState
{
    Vector2 moveVec;
    PlayerController player;

    public PlayerState_LockedInteraction(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.rb.velocity = Vector2.zero;
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Escape))
        {
            player.Interacted.Invoke();
        }

        // for emergencies, 
    }

    public void Exit()
    {
        player.rb.velocity = Vector2.zero;
    }

}
