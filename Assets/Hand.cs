using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isLeft = false;
    public bool isGrab = false;
    public float yPower = 200f;
    private Rigidbody2D rigid;
    private PlayerController playerController;
    private ConstantForce2D force;
    private bool isOverShelf = false;
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        force = this.GetComponent<ConstantForce2D>();

        playerController = GameObject.Find("Camera").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float yForce = 0;
        if (isLeft)
        {
            if (playerController.leftHand)
            {
                yForce = yPower;
                rigid.constraints = RigidbodyConstraints2D.None;
                playerController.isLeftGrabbed = false;
            }
            if (Input.GetKeyUp("k"))
            {
                if (isGrab && isOverShelf)
                {
                    rigid.constraints = RigidbodyConstraints2D.FreezePosition;
                    playerController.isLeftGrabbed = true;
                }

            }
        }
        else
        {
            if (playerController.rightHand)
            {
                yForce = yPower;
                rigid.constraints = RigidbodyConstraints2D.None;
                playerController.isRightGrabbed = false;
            }

            if (Input.GetKeyUp("l"))
            {
                if (isGrab && isOverShelf)
                {
                    rigid.constraints = RigidbodyConstraints2D.FreezePosition;
                    playerController.isRightGrabbed = true;

                }

            }

        }
        if (!playerController.isLeftGrabbed && !playerController.isRightGrabbed)
        {
            yForce = 0;
        }

        force.force = new Vector2(0, yForce);
       
           

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;
        isOverShelf = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;
        isOverShelf = false;
    }

}
