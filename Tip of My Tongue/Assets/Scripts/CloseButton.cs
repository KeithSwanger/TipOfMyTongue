using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    void OnCloseButtonClicked()
    {
        Application.Quit();
    }
}
