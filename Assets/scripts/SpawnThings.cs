using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThings : MonoBehaviour
{
    //GameObject / Things
    public State state;
    public List<float> paths;

    private string currentLevel;
    private List<string> prefabsUrls = new List<string>();

    ////position for paths
    float x;
    float y;
    float z;
    Vector3 pos;

    ////time
    public float minTimeSpawning = 3.0f;
    public float maxTimeSpawning = 6.0f;

    public float thingMassFrom = 1f;
    public float thingMassTo = 1f;

    private void Awake()
    {
        currentLevel = state.currentLevel.ToString();
    }
    //// start Time
    void Start()
    {
        LoadThings();
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

    //// Randomize things and paths
    public void SpawnRandom()
    {
        //position
        x = Random.Range(0, paths.Count);
        y = Camera.main.gameObject.transform.position.y + 5;
        pos = new Vector2(paths[(int)x], y);
        int randomIndex = Random.Range(0, prefabsUrls.Count);
        GameObject obj = Instantiate(Resources.Load(prefabsUrls[randomIndex]) as GameObject, transform.position = pos, Quaternion.identity);
        obj.tag = "endThing";
        obj.GetComponent<Rigidbody2D>().mass = Random.Range(thingMassFrom, thingMassTo);
    }

    private void LoadThings()
    {
        int lenght = state.levels[state.currentLevel-1].thingsVariantsCount;
        for(int i = 0; i < lenght; i++)
        {
            string str = "lvl" + currentLevel + "/things/" + (i + 1).ToString();
            prefabsUrls.Add(str);
        }
    }
}
