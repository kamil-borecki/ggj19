using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StepsSpawner : MonoBehaviour
{
    public State state;

    public int stepsCount = 10;
    public float stepDistance = 0.07f;
    public float stepDistanceRandomFactor = 0.05f;
    public float routeWidth = 0.3f;
    public float routeWidthRandomFactor = 0.1f;
    private List<GameObject> steps = new List<GameObject>();
    private bool updateOnce = true;
    private float currentHeight = 0;
    private string currentLevel;

    void Start()
    {
        //currentHeight = gameObject.GetComponent<MeshFilter>().mesh.bounds.min[1];
        currentLevel = state.currentLevelNumber.ToString();

        CreateSteps();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO ten if nie powinien sprawdzać co klatkę
        if (updateOnce)
        {
            UpdateStepsPositions();
        }
    }

    void CreateSteps() 
    {
        for(int i = 0; i < stepsCount; i++)
        {
            var step = CreateStep();
            steps.Add(step);
        }
    }

    void UpdateStepsPositions()
    {
        for (int i = 0; i<steps.Count; i++)
        {
            currentHeight += stepDistance;

            steps[i].transform.localPosition = new Vector3(-routeWidth + Random.Range(0f, routeWidthRandomFactor), currentHeight + Random.Range(0f, stepDistanceRandomFactor), -1);
            i++;
            steps[i].transform.localPosition = new Vector3(routeWidth + Random.Range(0f, routeWidthRandomFactor), currentHeight + Random.Range(0f, stepDistanceRandomFactor), -1);
        }
        updateOnce = !updateOnce;
    }

    private GameObject CreateStep()
    {
        string url = "lvl"+ currentLevel + "/prefabs/" + Random.Range(1, 4).ToString();
        Debug.Log(url);
        var tempObj = Instantiate(Resources.Load(url, typeof(GameObject)) as GameObject);
        tempObj.transform.SetParent(gameObject.transform);

        return tempObj;
    }
}
