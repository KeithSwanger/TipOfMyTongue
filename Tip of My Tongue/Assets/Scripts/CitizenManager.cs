using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEngine;
using UnityEngine.Events;

public class CitizenManager : MonoBehaviour
{
    int citizensRemaining;
    public List<Citizen> easyCitizens;
    public List<Citizen> mediumCitizens;
    public List<Citizen> hardCitizens;

    private List<Citizen> allCitizens;
    // Start is called before the first frame update

    public UnityEvent AllCitizensInteractedWithEvent = new UnityEvent();


    private void Awake()
    {
        allCitizens = new List<Citizen>();
        allCitizens.AddRange(easyCitizens);
        allCitizens.AddRange(mediumCitizens);
        allCitizens.AddRange(hardCitizens);

        foreach(Citizen c in allCitizens)
        {
            c.DiedEvent.AddListener(OnCitizenDiedOrSaved);
            c.SavedEvent.AddListener(OnCitizenDiedOrSaved);

        }

        citizensRemaining = allCitizens.Count;
    }


    public void ApplyAllRiddles()
    {
        List<Riddle> easyRiddles = Riddles.GetEasyRiddles();
        List<Riddle> mediumRiddles = Riddles.GetMediumRiddles();
        List<Riddle> hardRiddles = Riddles.GetHardRiddles();

        foreach (Citizen c in easyCitizens)
        {
            Riddle r = easyRiddles[Random.Range(0, easyRiddles.Count)];

            c.SetRiddle(r);
            easyRiddles.Remove(r);
        }

        foreach (Citizen c in mediumCitizens)
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

    private void OnCitizenDiedOrSaved(Citizen citizen)
    {
        citizensRemaining--;


        if(citizensRemaining <= 0)
        {
            AllCitizensInteractedWithEvent.Invoke();
        }
    }




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameResult GetGameResults()
    {
        int saved = 0;
        int killed = 0;
        int potentialScore = 0;
        int score = 0;

        foreach(Citizen c in allCitizens)
        {
            int s = 0;
            switch (c.riddle.difficulty)
            {
                case 0:
                    {
                        s = 30;
                        break;
                    }
                case 1:
                    {
                        s = 40;
                        break;
                    }
                case 2:
                    {
                        s = 50;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            potentialScore += s;


            if (c.isSaved)
            {
                score += s;
                saved++;
            }
            else if (c.isKilled)
            {
                killed++;
            }
        }

        return new GameResult(saved, killed, potentialScore, score);
    }


}
