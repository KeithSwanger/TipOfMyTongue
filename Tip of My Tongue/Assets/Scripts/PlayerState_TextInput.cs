using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_TextInput : IPlayerState
{
    List<KeyCode> validKeycodes = new List<KeyCode>()
    { 
        // Look at how dumb this is lol
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M,
        KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z,
    };

    bool deleteHeld = false;
    float deleteTimer = 0.3f;

    PlayerController player;
    public PlayerState_TextInput(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.playerInputBox.ShowPlayerInput();
    }

    public void Execute()
    {
        HandleInput();
    }

    private void HandleInput()
    {

        if (Input.GetKey(KeyCode.Backspace))
        {
            deleteHeld = true;
            deleteTimer -= Time.deltaTime;

            if(deleteTimer <= 0)
            {
                player.playerInputBox.RemoveCharacter();
                deleteTimer = 0.1f;
            }
        }
        else
        {
            deleteHeld = false;
            deleteTimer = 0.3f;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if(player.playerInputBox.GetPlayerInput() != string.Empty)
            {
                // Submit player input here
                player.AnswerSubmitted.Invoke(player.playerInputBox.GetPlayerInput());
            }

            player.SwitchState(new PlayerState_Move(this.player));
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.SwitchState(new PlayerState_Move(this.player));
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            player.playerInputBox.RemoveCharacter();
        }
        else
        {

            foreach (KeyCode k in validKeycodes)
            {
                if (Input.GetKeyDown(k))
                {
                    player.playerInputBox.AddCharacter(k.ToString()[0]);
                }
            }
        }

    }

    public void Exit()
    {
        player.playerInputBox.HidePlayerInput();
    }
}
