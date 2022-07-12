using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtInfoScript : MonoBehaviour
{
    private Vector3 thisPosition;
    [HideInInspector]
    public bool isThisLocationOccupied = false;

    [SerializeField] PositionAndOccupationScriptable scriptableToUpdate;
    

    [Header("testing only do not put in values")]

    [SerializeField] private bool isPlayerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        thisPosition.x = this.gameObject.transform.position.x;
        thisPosition.y = this.gameObject.transform.position.y;
        scriptableToUpdate.isOccupied = true;

    }

    public void SetDirtOccupied()
    {
        if(isPlayerInRange)
        {
            isThisLocationOccupied = true;
            scriptableToUpdate.isOccupied = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("player"))
        {
            scriptableToUpdate.xLocation = thisPosition.x;
            scriptableToUpdate.yLocation = thisPosition.y;
            scriptableToUpdate.isOccupied = isThisLocationOccupied;
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag.Equals("player"))
        {
            isPlayerInRange = false;

        }
    }
}
