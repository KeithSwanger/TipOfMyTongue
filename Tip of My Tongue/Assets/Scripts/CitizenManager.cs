using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CitizenManager : MonoBehaviour
{
    public List<Citizen> easyCitizens;
    public List<Citizen> mediumCitizens;
    public List<Citizen> hardCitizens;
    // Start is called before the first frame update



    private void Awake()
    {
        List<Riddle> easyRiddles = Riddles.GetEasyRiddles();
        List<Riddle> mediumRiddles = Riddles.GetMediumRiddles();
        List<Riddle> hardRiddles = Riddles.GetHardRiddles();

        foreach(Citizen c in easyCitizens)
        {
            Riddle r = easyRiddles[Random.Range(0, easyRiddles.Count)];

            c.SetRiddle(r);
            easyRiddles.Remove(r);
        }

        foreach(Citizen c in mediumCitizens)
        {
            Riddle r = mediumRiddles[Random.Range(0, mediumRiddles.Count)];
            c.SetRiddle(r);
            mediumRiddles.Remove(r);
        }

        foreach (Citizen c in hardCitizens)
        {
            Riddle r = hardRiddles[Random.Range(0, hardRiddles.Count)];
            c.SetRiddle(r);
            hardRiddles.Remove(r);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
