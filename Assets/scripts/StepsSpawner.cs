using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StepsSpawner : MonoBehaviour
{
    public int stepsCount = 10;

    private List<GameObject> steps = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        print(gameObject.transform.position.normalized);
        CreateSteps();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateSteps() 
    {
        for(int i = 0; i < stepsCount; i++)
        {
            var step = CreateStep(i);
            step.transform.localPosition = new Vector3(0, 0, 0);
            Debug.Log(step.name);
            Debug.Log(step.transform.position.normalized);
        }
    }

    private GameObject CreateStep(int number)
    {
        string objName = "Created step " + number.ToString();
        var tempObj = new GameObject(objName);
        tempObj.AddComponent<MeshFilter>();
        tempObj.AddComponent<BoxCollider2D>();
        tempObj.AddComponent<Rigidbody2D>();
        tempObj.transform.parent = gameObject.transform;

        return tempObj;
    }
}
