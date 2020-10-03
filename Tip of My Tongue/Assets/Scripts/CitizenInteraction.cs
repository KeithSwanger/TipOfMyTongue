using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenInteraction : MonoBehaviour
{
    public Citizen citizen;
    // Start is called before the first frame update
    private void Awake()
    {
        citizen = GetComponentInParent<Citizen>();
    }
    void Start()
    {
        
    }
}
