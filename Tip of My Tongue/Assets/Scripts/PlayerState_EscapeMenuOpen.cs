using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerState_EscapeMenuOpen : IPlayerState
{
    Vector2 moveVec;
    PlayerController player;

    public PlayerState_EscapeMenuOpen(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        this.player.rb.velocity = Vector2.zero;

        GameMananger.instance.escapeMenu.OpenEscapeMenu();
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.SwitchState(new PlayerState_Move(this.player));
        }
    }


    public void Exit()
    {
        GameMananger.instance.escapeMenu.CloseEscapeMenu();

    }

}
