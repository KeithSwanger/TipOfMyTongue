using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPlayerMove : MonoBehaviour
{
    public PlayerController player;
    public CanvasGroup canvasGroup;
    bool deleteGameObject = false;
    // Update is called once per frame
    void Update()
    {
        if(player.rb.velocity != Vector2.zero)
        {
            deleteGameObject = true;
        }

        if (deleteGameObject)
        {
            if (canvasGroup.alpha <= 0f)
            {
                GameObject.Destroy(this.gameObject);
            }
            else
            {
                canvasGroup.alpha -= Time.deltaTime;
            }
        }
    }
}
