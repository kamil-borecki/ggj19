using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHeight;


    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHeight = groundCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(groundHeight);
    }
    void OnBecameInvisible()
    {
        Debug.Log("invisible " + transform.name);
        if(Camera.main.transform.position.y > transform.position.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + groundHeight);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - groundHeight);

        }
    }
}
