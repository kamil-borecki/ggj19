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

    public Level(int steps, int stepsVar, float stepDist, 
    float stepDistRand, float route, float routeWidthRand)
    {
        stepsCount = steps;
        stepsVariations = stepsVar;
        stepDistance = stepDist;
        stepDistanceRandomFactor = stepDistRand;
        routeWidth = route;
        routeWidthRandomFactor = routeWidthRand;
    }
}
