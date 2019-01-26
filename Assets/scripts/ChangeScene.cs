using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string cutSceneName = "cutscene";

    void OnTriggerEnter2D(Collider2D colider)
    {
        // TODO SETUP TAG ON CORPSE
        if (colider.tag == "Player")
        {
            SceneManager.LoadSceneAsync(cutSceneName);
        }
    }
}
