using UnityEngine;
using System.Collections;

public class Level
{
    public int stepsCount;
    public int stepsVariations;
    public int thingsVariantsCount;
    public float stepDistance;
    public float stepDistanceRandomFactor;
    public float routeWidth;
    public float routeWidthRandomFactor;

    public Level(LevelSettings levelSettings)
    {
        stepsCount = levelSettings.stepsCount;
        stepsVariations = levelSettings.stepsVariantsCount;
        thingsVariantsCount = levelSettings.thingsVariantsCount;
        stepDistance = levelSettings.spaceBeetwenSteps;
        stepDistanceRandomFactor = levelSettings.stepsDistanceFactor;
        routeWidth = levelSettings.routeWidth;
        routeWidthRandomFactor = levelSettings.routeWidthFactor;
    }
}
