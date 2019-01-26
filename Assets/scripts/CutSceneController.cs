using UnityEngine;
using System.Collections;

public class CutSceneController : MonoBehaviour
{
    public State state;

    // Use this for initialization
    void Start()
    {
        string url = "Assets/Resources/lvl" + state.currentLevel + "/video/1.mp4";
        gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().url = url;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
