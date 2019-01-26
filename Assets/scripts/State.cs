using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu()]
public class State : ScriptableObject
{
    public List<Level> levels = new List<Level>();
    public int currentLevel = 0;
    public int nextLevel = 1;
    public int stepsVariations = 3;
    public GameObject background;
}
