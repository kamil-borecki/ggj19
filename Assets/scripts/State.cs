using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LevelSettings
{
    public int stepsCount, stepsVariantsCount, thingsVariantsCount;
    public float spaceBeetwenSteps, stepsDistanceFactor, routeWidth, routeWidthFactor;
}

[CreateAssetMenu()]
public class State : ScriptableObject
{
    public List<Level> levels = new List<Level>();
    public int currentLevel = 0;
    public int nextLevel = 1;
    public GameObject background;

    public List<LevelSettings> levelSettings;
   

    private void OnEnable()
    {
        //public Level(int steps, int stepsVar, float stepDist, float stepDistRand, float route, float routeWidthRand)

        foreach(LevelSettings levelSetting in levelSettings)
        {
            levels.Add(new Level(levelSetting));
        }
       
    }
}
