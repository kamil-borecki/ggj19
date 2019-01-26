using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool right, left, leftHand, rightHand, isLeftGrabbed, isRightGrabbed;
    void Start()
    {
        isLeftGrabbed = isRightGrabbed = true;
    }

    // Update is called once per frame
    void Update()
    {

        right = left = leftHand = rightHand = false;
        if(Input.GetKey("a")){
            left = true;
        }
        if (Input.GetKey("d"))
        {
            right = true;
        }
        if (Input.GetKey("k"))
        {
            leftHand = true;
        }
        if (Input.GetKey("l"))
        {
            rightHand = true;
        }
    }
}
