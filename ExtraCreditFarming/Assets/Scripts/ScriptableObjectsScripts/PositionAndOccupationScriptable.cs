using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Position and Occupied Scriptable")]
public class PositionAndOccupationScriptable : ScriptableObject
{
    public bool isOccupied = false;
    public float xLocation;
    public float yLocation;
    //while i could just use everything from currentSquare, the above 2 vars are better for readability
}
