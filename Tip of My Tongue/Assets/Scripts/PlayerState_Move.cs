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
        ProcessInput();

        player.rb.velocity = moveVec * player.moveSpeed;
    }

    private void ProcessInput()
    {
        moveVec = Vector2.zero;

        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.y = Input.GetAxisRaw("Vertical");

        if (moveVec.sqrMagnitude > 1f)
        {
            moveVec = moveVec.normalized;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (player.citizenInteractingWith != null)
            {
               if(player.citizenInteractingWith.riddle != null)
                {
                    player.SwitchState(new PlayerState_TextInput(this.player));
                }
                else
                {
                    player.Interacted.Invoke();
                }
            }
        }
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

}
