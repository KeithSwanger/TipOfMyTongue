using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject focusPoint;

    public int cameraSpeed = 1;

    [HideInInspector]
    public Camera mainCamera;

    void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(focusPoint != null)
        {
            //Vector2 newLocation = Vector2.MoveTowards(gameObject.transform.position, focusPoint.transform.position, Time.deltaTime * cameraSpeed);
            Vector2 newLocation = Vector2.Lerp(gameObject.transform.position, focusPoint.transform.position, cameraSpeed * Time.deltaTime);
            gameObject.transform.position = new Vector3(newLocation.x, newLocation.y, transform.position.z);
        }

    }
}
