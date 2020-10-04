using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult
{
    public int savedCitizens = 0;
    public int killedCitizens = 0;

    public int potentialScore = 0;
    public int score = 0;

    float gradeRatio = 0f;
    public string grade = "F";

    public Color gradeColor = Color.black;



    public GameResult(int savedCitizens, int killedCitizens, int potentialScore, int score)
    {
        this.savedCitizens = savedCitizens;
        this.killedCitizens = killedCitizens;
        this.potentialScore = potentialScore;
        this.score = score;



        if (score == potentialScore)
        {
            this.gradeRatio = 1f;
        }
        else
        {
            this.gradeRatio = (float)score / (float)potentialScore;
        }


        if (gradeRatio == 1f)
        {
            grade = "a+";
            ColorUtility.TryParseHtmlString("#FFD700", out gradeColor);
        }
        else if (gradeRatio >= 0.9f)
        {
            grade = "a";
            ColorUtility.TryParseHtmlString("#00FF00", out gradeColor);

        }
        else if (gradeRatio >= 0.8f)
        {
            grade = "b";
            ColorUtility.TryParseHtmlString("#222222", out gradeColor);

        }
        else if (gradeRatio >= 0.7f)
        {
            grade = "c";
            ColorUtility.TryParseHtmlString("#222222", out gradeColor);
        }
        else if (gradeRatio >= 0.6f)
        {
            grade = "d";
            ColorUtility.TryParseHtmlString("#222222", out gradeColor);
        }
        else
        {
            grade = "f";
            ColorUtility.TryParseHtmlString("#FF0000", out gradeColor);
        }

    }
}

