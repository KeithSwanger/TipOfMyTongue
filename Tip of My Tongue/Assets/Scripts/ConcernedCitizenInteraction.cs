using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcernedCitizenInteraction : MonoBehaviour
{
    public ConcernedCitizen concernedCitizen;
    // Start is called before the first frame update
    private void Awake()
    {
        concernedCitizen = GetComponentInParent<ConcernedCitizen>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInteraction>()?.player is PlayerController player)
        {
            player.Interacted.AddListener(concernedCitizen.OnPlayerInteract);
        }
     }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInteraction>()?.player is PlayerController player)
        {
            player.Interacted.RemoveListener(concernedCitizen.OnPlayerInteract);
        }
    }
}
