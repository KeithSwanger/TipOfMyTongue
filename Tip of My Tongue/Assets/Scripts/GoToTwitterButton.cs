using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToTwitterButton : MonoBehaviour
{
    public Button socialMediaButton;

    private void Awake()
    {
        socialMediaButton.onClick.AddListener(OpenTwitter);
    }

    void OpenTwitter()
    {
        Application.OpenURL("https://www.twitter.com/KeithSwanger");
    }
}
