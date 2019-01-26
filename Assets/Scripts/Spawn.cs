using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
     
    public GameObject[] things;
          
    //public float spawnTime = 2f;            // How long between each spawn.
    //private float timer = 0; //counting timer, reset after calling SpawnRandom() function


    //position
    float x;
    float y;
    float z;
    Vector3 pos;

    //time
    public float minSecondsBetweenSpawning = 3.0f;
    public float maxSecondsBetweenSpawning = 6.0f;

    private float savedTime;
    private float secondsBetweenSpawning;



    void Start()
    {
        savedTime = Time.time;
        secondsBetweenSpawning = Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
    }

    void Update()
    {
        //timer += Time.deltaTime;   // Timer Counter
        //if (timer > spawnTime)
        //{
            //SpawnRandom();       //Calling method SpawnRandom()
            //timer = 0;        //Reseting timer to 0
        //}
        if (Time.time - savedTime >= secondsBetweenSpawning) // is it time to spawn again?
        {
            SpawnRandom();
            savedTime = Time.time; // store for next spawn
            secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
        }   

    }
    public void SpawnRandom()
    {
        x = Random.Range(-7, 7);
        y = 15;
        z = -6;
        pos = new Vector3(x, y, z);
        int randomIndex = Random.Range(0, 2);
        //Instantiation of the Object
        Instantiate(things[randomIndex], transform.position = pos, Quaternion.identity);
    }
}