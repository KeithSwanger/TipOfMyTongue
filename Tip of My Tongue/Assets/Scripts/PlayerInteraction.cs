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
        Debug.Log($"We in {collision.gameObject}");


        Citizen citizen = collision.gameObject.GetComponent<CitizenInteraction>()?.citizen;

        if (citizen != null)
        {
            Debug.Log("We're interacting with a citizen!");
            player.citizenInteractingWith = citizen;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"We left {collision.gameObject}");
        player.citizenInteractingWith = null;
    }
}
