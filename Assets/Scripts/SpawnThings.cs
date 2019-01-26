using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThings : MonoBehaviour
{
    //GameObject / Things
    public GameObject[] things;

    //List Pool
    //[System.Serializable]
    //public class Pool
    //{
    //    public int group;
    //    public GameObject prefab;
    //    //public int size;
    //}

    //public List<Pool> pools;
    //public List<Queue<GameObject>> queueList = new List<Queue<GameObject>>();
    //private Queue<GameObject> objectPool = new Queue<GameObject>()

    ////position for paths
    float x;
    float y;
    float z;
    Vector3 pos;
    public List<float> paths;

    ////time
    public float minTimeSpawning = 3.0f;
    public float maxTimeSpawning = 6.0f;


    //// start Time
    void Start()
    {
    //    //Making Pool
    //    foreach (Pool pool in pools)
    //    {
    //        Queue<GameObject> objectPool;
    //        for (int i = 0; i < pool.size; i++)
    //        {
    //            GameObject obj = Instantiate(pool.prefab);
    //        obj.SetActive(false);
    //        //objectPool.Enqueue(obj);
    //     }
    //        queueList[pool.group] = objectPool;
    //    }

    //    //Calling to start Time
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
        y = 15;
        z = 0;
        pos = new Vector3(paths[(int)x], y, z);

    //    //Gameobject/things
        int randomIndex = Random.Range(0, things.Length);

    //    int i = Random.Range(0, queueList.Count);
    //    GameObject obj = new GameObject();
    //    obj = queueList[i].Dequeue();
    //    //Instantiation of the Object
    //    obj.SetActive(true);
         Instantiate(things[randomIndex], transform.position = pos, Quaternion.identity);
    }
 
}