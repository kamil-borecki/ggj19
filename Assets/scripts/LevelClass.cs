using UnityEngine;
using System.Collections;

public class Level
{
    public int stepsCount;
    public int stepsVariations;
    public float stepDistance;
    public float stepDistanceRandomFactor;
    public float routeWidth;
    public float routeWidthRandomFactor;

    public Level(LevelSettings levelSettings)
    {
        stepsCount = levelSettings.stepsCount;
        stepsVariations = levelSettings.stepsVariantsCount;
        stepDistance = levelSettings.spaceBeetwenSteps;
        stepDistanceRandomFactor = levelSettings.stepsDistanceFactor;
        routeWidth = levelSettings.routeWidth;
        routeWidthRandomFactor = levelSettings.routeWidthFactor;
    }
}
