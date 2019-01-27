using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public float newYPos = 0f;
    public float speed;
    public float offset;
    public Player player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         // calculate distance to move

        if (newYPos > 0f )
        {
            float step = speed * Time.deltaTime;
            Vector2 targetPos = new Vector2(transform.position.x, newYPos);
            transform.position = Vector2.Lerp(transform.position, targetPos, step);

        }
        float playerX = player.transform.position.x;
        if(playerX < offset && playerX > -offset)
        {
            float step = speed/2 * Time.deltaTime;
            Vector2 targetPos2 = new Vector2(playerX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, targetPos2, step);
        }
      
    }
}
