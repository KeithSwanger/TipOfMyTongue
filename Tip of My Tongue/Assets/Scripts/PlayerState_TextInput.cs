using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_TextInput : IPlayerState
{
    PlayerController player;
    public PlayerState_TextInput(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
