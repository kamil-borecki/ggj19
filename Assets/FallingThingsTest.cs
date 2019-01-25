using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingThings : MonoBehaviour
{
    public float fallSpeed = 8.0f;


    void Update()
    {

        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

    }

    void OnMouseDown()
    {

        GetComponent<Renderer>().enabled = false;

    }

}


