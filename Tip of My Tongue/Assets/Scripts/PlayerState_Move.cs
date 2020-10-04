using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerState_Move : IPlayerState
{
    Vector2 moveVec;
    PlayerController player;

    public PlayerState_Move(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {

    }

    public void Execute()
    {
        if (!ProcessInput())
        {
            return;
        }

        player.rb.velocity = moveVec * player.moveSpeed;
    }

    private bool ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            player.SwitchState(new PlayerState_EscapeMenuOpen(this.player));
            return false;
        }

        moveVec = Vector2.zero;

        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.y = Input.GetAxisRaw("Vertical");

        if (moveVec.sqrMagnitude > 1f)
        {
            moveVec = moveVec.normalized;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            if (player.citizenInteractingWith != null && player.citizenInteractingWith.riddle != null && !player.citizenInteractingWith.isSaved && !player.citizenInteractingWith.isKilled)
            {
                player.SwitchState(new PlayerState_TextInput(this.player));
                return false;
            }
            else
            {
                player.Interacted.Invoke();
            }
        }

        if(moveVec != Vector2.zero)
        {
            player.StartWalkAnimation();
        }
        else
        {
            player.StartIdleAnimation();
        }

        return true;
    }

    public void Exit()
    {
        player.rb.velocity = Vector2.zero;
        player.StartIdleAnimation();
    }

}
