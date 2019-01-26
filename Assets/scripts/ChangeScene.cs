using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public State state;
    public string cutSceneName = "CutScene";

    private bool temp = false; //top of level reached - To Be Implemented

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (temp)
        {
            SceneManager.LoadSceneAsync(cutSceneName);
        }
    }
}
