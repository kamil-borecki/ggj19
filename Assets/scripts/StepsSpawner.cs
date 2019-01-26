using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StepsSpawner : MonoBehaviour
{
    public State state;

    private int stepsCount;
    private int stepsVariations;
    private float stepDistance;
    private float stepDistanceRandomFactor;
    private float routeWidth;
    private float routeWidthRandomFactor;
    private string currentLevel;

    private GameObject finishLine;

    private float currentHeight = 0;
    private List<GameObject> steps = new List<GameObject>();

    // TODO get rid of this
    private bool stepsMoved = false;

    void Start()
    {
        SetupLevel(state.levels[state.currentLevel-1]);
        currentLevel = state.currentLevel.ToString();
        CreateSteps();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO ten if nie powinien sprawdzać co klatkę
        if (!stepsMoved)
        {
            UpdateStepsPositions();
        }
    }

    private void SetupLevel(Level level)
    {
        stepsCount = level.stepsCount;
        stepsVariations = level.stepsVariations;
        stepDistance = level.stepDistance;
        stepDistanceRandomFactor = level.stepDistanceRandomFactor;
        routeWidth = level.routeWidth;
        routeWidthRandomFactor = level.routeWidthRandomFactor;
    }

    private void CreateSteps()
    {
        for(int i = 0; i < stepsCount; i++)
        {
            steps.Add(CreateStep());
        }
        CreateFinalStepColider();
    }

    private void UpdateStepsPositions()
    {
        for (int i = 0; i<steps.Count; i++)
        {
            currentHeight += stepDistance;

            steps[i].transform.localPosition = new Vector2(-routeWidth + Random.Range(0f, routeWidthRandomFactor), currentHeight + Random.Range(0f, stepDistanceRandomFactor));
            if (steps[i+1])
            {
                i++;
                steps[i].transform.localPosition = new Vector2(routeWidth + Random.Range(0f, routeWidthRandomFactor), currentHeight + Random.Range(0f, stepDistanceRandomFactor));
            }
        }

        finishLine.transform.localPosition = new Vector2(-routeWidth, currentHeight);

        stepsMoved = !stepsMoved;
    }

    private GameObject CreateStep()
    {
        string url = "lvl" + currentLevel + "/steps/" + Random.Range(1, stepsVariations+1).ToString();
        Debug.Log(url);
        var tempObj = Instantiate(Resources.Load(url, typeof(GameObject)) as GameObject);
        tempObj.transform.SetParent(gameObject.transform);

        return tempObj;
    }

    private void CreateFinalStepColider()
    {
        finishLine = Instantiate(Resources.Load("common/finisher", typeof(GameObject)) as GameObject);
        finishLine.transform.SetParent(gameObject.transform);
    }
}
