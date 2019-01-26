using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu()]
public class State : ScriptableObject
{
    public List<Level> levels = new List<Level>();
    public int currentLevel = 0;
    public int nextLevel = 1;
    public GameObject background;

    private void OnEnable()
    {
        //public Level(int steps, int stepsVar, float stepDist, float stepDistRand, float route, float routeWidthRand)
        levels.Add(new Level(8, 3, 0.9f, 0.05f, 0.7f, 0.1f));
        levels.Add(new Level(12, 3, 1.3f, 0.05f, 0.7f, 0.1f));
        levels.Add(new Level(16, 3, 1.1f, 0.05f, 0.7f, 0.1f));
    }
}
