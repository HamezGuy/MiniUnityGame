using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I know its specific, this is just a extra project
public class ScriptInstanciateObjects : MonoBehaviour
{
    [SerializeField] protected Transform startingPosition;
    [SerializeField] protected int numberOfRowsAndColumns;

    [SerializeField] protected GameObject objectToInstanciate;
    private float xLocation;
    private float yLocation;

    // Start is called before the first frame update
    void Start()
    {
        xLocation = startingPosition.position.x;
        yLocation = startingPosition.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
