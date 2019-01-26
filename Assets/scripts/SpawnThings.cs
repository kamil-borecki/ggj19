using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThings : MonoBehaviour
{
    //GameObject / Things
    public GameObject[] things;

   

    ////position for paths
    float x;
    float y;
    float z;
    Vector3 pos;
    public List<float> paths;

    ////time
    public float minTimeSpawning = 3.0f;
    public float maxTimeSpawning = 6.0f;

    public float thingMassFrom = 1f;
    public float thingMassTo = 1f;


    //// start Time
    void Start()
    {
         StartCoroutine(Time());
    }

    ////random Time
    IEnumerator Time()
    {
            float waitTime = Random.Range(minTimeSpawning, maxTimeSpawning);
            yield return new WaitForSeconds(waitTime);
            SpawnRandom();
            StartCoroutine(Time());
    }


    //void Update()
    //{
      
    //}

    //// Randomize things and paths
    public void SpawnRandom()
    {
    //    //position
        x = Random.Range(0, paths.Count);
        y = Camera.main.gameObject.transform.position.y + 5;
        pos = new Vector2(paths[(int)x], y);
        int randomIndex = Random.Range(0, things.Length);
        GameObject obj = Instantiate(things[randomIndex], transform.position = pos, Quaternion.identity);
        obj.tag = "endThing";
        obj.GetComponent<Rigidbody2D>().mass = Random.Range(thingMassFrom, thingMassTo);

    }
 
}