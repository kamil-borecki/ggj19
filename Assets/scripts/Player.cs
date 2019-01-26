using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float xPower = 200f;
    public float yPower = 200f;
    public State state;
    public string cutSceneName = "cutscene";
    private ConstantForce2D force;
    private PlayerController playerController;
    private Rigidbody2D rigid;
    private Animator headAnimator;
    private GameObject head;
    void Start()
    {
       force = this.GetComponent<ConstantForce2D>();
        head = GameObject.Find("Head");
        headAnimator = head.GetComponent<Animator>();
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
        if(xForce != 0)
        {
            headAnimator.SetBool("looking", true);
            if(xForce < 0)
            {
                head.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                head.GetComponent<SpriteRenderer>().flipX = false;

            }
        }
        else
        {
            headAnimator.SetBool("looking", false);
        }
        force.force = new Vector2(xForce, yForce);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "end")
        { 
            state.currentLevel = 0;
            state.nextLevel = 1;
            SceneManager.LoadSceneAsync(cutSceneName);
        }
    }
}
