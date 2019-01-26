using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ThingColider : MonoBehaviour
{
    public State state;
    public string cutSceneName = "cutscene";

    void OnTriggerEnter2D(Collider2D colider)
    {
        // TODO SET TAG ON PLAYER
        if (colider.tag == "corpse")
        {
            Loose();
        }
        if (colider.tag == "end")
        {
            Destroy(gameObject);
        }

    }

    private void Loose()
    {
        state.currentLevel = 0;
        state.nextLevel = 1;
        SceneManager.LoadSceneAsync(cutSceneName);
    }
}
