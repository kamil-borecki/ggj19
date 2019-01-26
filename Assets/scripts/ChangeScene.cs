using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string cutSceneName = "cutscene";

    void OnTriggerEnter2D()
    {
        SceneManager.LoadSceneAsync(cutSceneName);
    }
}
