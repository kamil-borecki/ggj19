using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneController : MonoBehaviour
{
    public State state;
    public string gameSceneName = "test";

    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        string url = "Assets/Resources/lvl" + state.currentLevel + "/video/1.mp4";
        videoPlayer.url = url;
        videoPlayer.loopPointReached += LoadScene;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadSceneAsync("test");
    }
}
