using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string cutSceneName = "cutscene";

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.name == "User" || colider.transform.parent.gameObject.name == "User")
        {
            SceneManager.LoadSceneAsync(cutSceneName);
        }
    }
}
