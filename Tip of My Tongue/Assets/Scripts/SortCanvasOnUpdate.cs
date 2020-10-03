using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCanvasOnUpdate : MonoBehaviour
{
    public Canvas canvas = null;

    public int offset = 0;


    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canvas.sortingOrder = -Mathf.FloorToInt(canvas.transform.position.y * 1000 - offset * canvas.transform.position.y * 1000 / 100);
    }
}
