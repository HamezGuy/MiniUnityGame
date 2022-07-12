using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateObject : MonoBehaviour
{
    [SerializeField] Transform positionToStartAt;
    [SerializeField] private GameObject gameObjectToInstanciate;
    [SerializeField] int numberOfRowsAndColumns = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void PopulateObjects()
    {
        for(int i = 0; i < numberOfRowsAndColumns; i++)
        {
            
        }
    }

    private void PopulateRow()
    {

    }
}
