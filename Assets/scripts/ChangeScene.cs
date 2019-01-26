using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string cutSceneName = "CutScene";

    private bool temp = false; //last step reached - To Be Implemented
    private bool m_SceneLoaded = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DestroyScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (temp && m_SceneLoaded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(cutSceneName));
        }
    }

    IEnumerator PreloadScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(cutSceneName);
        while (!async.isDone)
        {
            yield return null;
        }
        m_SceneLoaded = true;
    }

    IEnumerator DestroyScene()
    {
        yield return new WaitForSeconds(10);
        AsyncOperation async = SceneManager.UnloadSceneAsync(cutSceneName);
        while (async.isDone)
        {
            yield return StartCoroutine(PreloadScene());
        }
    }
}
