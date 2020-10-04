using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
    }

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<CitizenInteraction>()?.citizen is Citizen citizen)
        {
            player.citizenInteractingWith = citizen;
        }
        else if(collision.gameObject.GetComponent<ConcernedCitizenInteraction>()?.concernedCitizen is ConcernedCitizen concernedCitizen)
        {
            if (concernedCitizen.isFirstInteraction)
            {
                player.SwitchState(new PlayerState_LockedInteraction(this.player));
                concernedCitizen.InitialConversationOver.AddListener(player.UnlockPlayer);
                concernedCitizen.StartInitialConversation();
            }
            else if (player.gameMananger.isGameComplete)
            {
                player.SwitchState(new PlayerState_LockedInteraction(this.player));
                concernedCitizen.EndingConversationOver.AddListener(player.gameMananger.EndGame);
                concernedCitizen.StartEndingConversation();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.citizenInteractingWith = null;
    }
}
