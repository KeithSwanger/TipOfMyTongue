using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortSpriteOnUpdate : MonoBehaviour
{
    SpriteRenderer sr;

    public int offset = 0;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sr.sortingOrder = -Mathf.FloorToInt(gameObject.transform.position.y * 1000);
    }
}
