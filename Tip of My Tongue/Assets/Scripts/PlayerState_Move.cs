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
        moveVec = Vector2.zero;

        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.y = Input.GetAxisRaw("Vertical");

        if (moveVec.sqrMagnitude > 1f)
        {
            moveVec = moveVec.normalized;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            if (player.citizenInteractingWith != null)
            {
               if(player.citizenInteractingWith.riddle != null && !player.citizenInteractingWith.isSaved)
                {
                    player.SwitchState(new PlayerState_TextInput(this.player));
                    return false;
                }
                else
                {
                    player.Interacted.Invoke();
                }
            }
        }

        return true;
    }

    public void Exit()
    {
        player.rb.velocity = Vector2.zero;
    }

}
