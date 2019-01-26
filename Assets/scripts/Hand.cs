using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool isGrabbed = false;

    public State state;
    public string cutSceneName = "cutscene";

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
                isGrabbed = false;
            }
        }
        else
        {
            if (playerController.rightHand)
            {
                yForce = yPower;
                rigid.constraints = RigidbodyConstraints2D.None;
                playerController.isRightGrabbed = false;
                isGrabbed = false;
            }
        }
        if (!playerController.isLeftGrabbed && !playerController.isRightGrabbed)
        {
            yForce = 0;
        }
        force.force = new Vector2(0, yForce);

        if (isGrab)
        {
            gameObject.GetComponent<Animator>().SetBool("grabbed", isGrabbed);

        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "shelf")
        {
            isOverShelf = true;
        }
        if(col.tag == "end")
        {
            state.currentLevel = 0;
            state.nextLevel = 1;
            SceneManager.LoadSceneAsync(cutSceneName);
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "shelf")
        {
            isOverShelf = false;
        }

    }
    void HandEnd()
    {

      
        if (isGrab && isOverShelf)
        {
            isGrabbed = true;
            rigid.constraints = RigidbodyConstraints2D.FreezePosition;
            if (isLeft)
            {
                playerController.isLeftGrabbed = true;
            }
            else
            {
                playerController.isRightGrabbed = true;

            }
        }
   
    }

}
