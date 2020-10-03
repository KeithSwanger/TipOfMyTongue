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
        Citizen citizen = collision.gameObject.GetComponent<CitizenInteraction>()?.citizen;

        if (citizen != null)
        {
            player.citizenInteractingWith = citizen;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.citizenInteractingWith = null;
    }
}
