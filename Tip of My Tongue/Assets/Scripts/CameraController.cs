using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject focusPoint;

    public Tilemap tilemapToStayWithin;

    public int cameraSpeed = 1;
    public float cameraHeight = 0f;
    public float cameraWidth = 0f;

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


        // This only works for tiles that are not in positive coordinates, i'm a dumb dumb and will fix it later
        cameraHeight = 2f * this.mainCamera.orthographicSize;
        cameraWidth = cameraHeight * this.mainCamera.aspect;

        Vector3 finalPosition = gameObject.transform.position;

        if (finalPosition.x < cameraWidth / 2f + tilemapToStayWithin.transform.position.x)
        {
            finalPosition.x = cameraWidth / 2f + tilemapToStayWithin.transform.position.x;
        }
        else if (finalPosition.x > tilemapToStayWithin.transform.position.x + (tilemapToStayWithin.cellBounds.xMax * tilemapToStayWithin.cellSize.x) - cameraWidth / 2f)
        {
            finalPosition.x = tilemapToStayWithin.transform.position.x + (tilemapToStayWithin.cellBounds.xMax * tilemapToStayWithin.cellSize.x) - (cameraWidth / 2f);
        }

        if (finalPosition.y < cameraHeight / 2f + tilemapToStayWithin.transform.position.y)
        {
            finalPosition.y = cameraHeight / 2f + tilemapToStayWithin.transform.position.y;
        }
        else if (finalPosition.y > tilemapToStayWithin.transform.position.y + (tilemapToStayWithin.cellBounds.yMax * tilemapToStayWithin.cellSize.y) - cameraHeight / 2f)
        {
            finalPosition.y = tilemapToStayWithin.transform.position.y + (tilemapToStayWithin.cellBounds.yMax * tilemapToStayWithin.cellSize.y) - (cameraHeight / 2f);
        }

        gameObject.transform.position = finalPosition;

    }
}
