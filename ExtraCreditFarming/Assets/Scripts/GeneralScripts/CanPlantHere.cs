using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPlantHere : MonoBehaviour
{
    [SerializeField] protected BooleanScriptable canPlantHere;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("player"))
        {
            canPlantHere.booleanValue = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag.Equals("player"))
        {
            canPlantHere.booleanValue = false;
        }
    }
}
