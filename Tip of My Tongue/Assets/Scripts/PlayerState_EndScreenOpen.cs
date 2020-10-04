using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_EndScreenOpen : MonoBehaviour
{
    Vector2 moveVec;
    PlayerController player;

    public PlayerState_EndScreenOpen(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        this.player.rb.velocity = Vector2.zero;
    }

    public void Execute()
    {
    }


    public void Exit()
    { 
    }

}
