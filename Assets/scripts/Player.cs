using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float xPower = 200f;
    public float yPower = 200f;
    private ConstantForce2D force;
    private PlayerController playerController;
    private Rigidbody2D rigid;
    void Start()
    {
       force = this.GetComponent<ConstantForce2D>();
        rigid = this.GetComponent<Rigidbody2D>();
        playerController = GameObject.Find("Camera").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xForce = 0;
        float yForce = 0;
        if (playerController.left)
        {
            xForce += -xPower;
            yForce = yPower;
        }
        if (playerController.right)
        {
            xForce += xPower;
            yForce = yPower;
        }
        if(playerController.leftHand || playerController.rightHand)
        {
            yForce = yPower;
        }
        if (!playerController.isLeftGrabbed && !playerController.isRightGrabbed) {
            xForce = yForce = 0;
        }
        force.force = new Vector2(xForce, yForce);

    }
}
