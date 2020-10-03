using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Riddle
{
    List<string> acceptedAnswers = new List<string>();
    List<string> hints = new List<string>();

    public Riddle(List<string> answers, List<string> hints)
    {
        this.acceptedAnswers = answers;
        this.hints = hints;
    }


    public bool TryAnswer(string answer)
    {
        if(answer == null)
        {
            return false;
        }

        foreach(string a in acceptedAnswers)
        {
            if (answer.Trim().ToLower() == a.Trim().ToLower())
            {
                // answer found
                return true;
            }
        }

        // answer not found
        return false;
    }

    public List<string> GetAllHints()
    {
        return hints.ToList();
    }
}
