using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    public CanvasGroup endScreenCanvasGroup;

    public TMP_Text savedCitizensText;
    public TMP_Text killedCitizensText;

    public TMP_Text potentialScoreText;
    public TMP_Text scoreText;

    public TMP_Text gradeText;

    bool showEndScreen = false;


    private void Awake()
    {
        if(!showEndScreen)
        { 
            endScreenCanvasGroup.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (showEndScreen)
        {
            if(endScreenCanvasGroup.alpha < 1f)
            {
                endScreenCanvasGroup.alpha += Time.deltaTime;
            }
        }
    }
    public void ShowEndScreen(GameResult results)
    {
        savedCitizensText.text = $"Citizens saved: {results.savedCitizens.ToString()}";
        killedCitizensText.text = $"Citizens died: {results.killedCitizens.ToString()}";
        potentialScoreText.text = $"Potential score: {results.potentialScore.ToString()}";
        scoreText.text = $"{results.score.ToString()}";

        gradeText.text = results.grade;
        gradeText.color = results.gradeColor;

        endScreenCanvasGroup.alpha = 0f;
        endScreenCanvasGroup.gameObject.SetActive(true);
        showEndScreen = true;
        
    }
}
