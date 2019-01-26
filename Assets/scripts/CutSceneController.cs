using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneController : MonoBehaviour
{
    public State state;

    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        string url = "Assets/Resources/lvl" + state.currentLevel + "/video/1.mp4";
        videoPlayer.url = url;
        videoPlayer.loopPointReached += PreloadScene;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PreloadScene(VideoPlayer vp)
    {
        SceneManager.LoadSceneAsync("test");
    }

    private void LoadScene(VideoPlayer vp)
    {

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("test"));
    }
}
