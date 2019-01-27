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
        if(state.currentLevel < state.levelSettings.Count)
        {
            videoPlayer = gameObject.GetComponent<VideoPlayer>();
            string url = "Assets/Resources/lvl" + state.currentLevel + "/video/1.mp4";
            Debug.Log(url);


            videoPlayer.url = url;
            videoPlayer.loopPointReached += LoadScene;
        }
    }

    private void LoadScene(VideoPlayer vp)
    {
        if (state.currentLevel < state.levelSettings.Count)
        {

            SceneManager.LoadSceneAsync(state.levelSettings[state.currentLevel].sceneName);
            state.currentLevel++;
            state.nextLevel++;
        }
    }
}
