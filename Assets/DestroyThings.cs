using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThings : MonoBehaviour
{
    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
