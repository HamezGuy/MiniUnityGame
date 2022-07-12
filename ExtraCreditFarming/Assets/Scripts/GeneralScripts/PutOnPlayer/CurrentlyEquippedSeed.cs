using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//switches currently equipped seed at user input. 
//THIS WONT' WORK LOGICALLY, FIGURE OUT ANOTHER WAY.
[System.Serializable]
public class CurrentlyEquippedSeed : MonoBehaviour
{
    public SeedGenotypeNoMonobehavior currentFruitInInventory = null;
    
    public ListOfAllFruitsInInventory listOfAllFruits;

    [SerializeField] Signal signalToRaise;


    void Start()
    {
        currentFruitInInventory = null;
        Invoke("setfruittonull", .1f);
    }
    void setfruittonull()
    {
        currentFruitInInventory = null;
    }

    void Update()
    {
        
        SetCurrentlyEquippedSeedIfNotEquipped();
        if(Input.GetButtonDown("switchSeed"))
        {
            
            SwitchCurrentSeed();
            
        }
    }
    public void SetCurrentlyEquippedSeedIfNotEquipped()
    {
        if(currentFruitInInventory != null)
        {
            
            return;
        }
        if(listOfAllFruits.listOfAllInventoryFruits.Count == 0)
        {
            return;
        }
        for(int i = 0; i < listOfAllFruits.listOfAllInventoryFruits.Count; i++)
        {
            if(listOfAllFruits.listOfAllInventoryFruits[i] != null)
            {
                currentFruitInInventory = listOfAllFruits.listOfAllInventoryFruits[i];
                
                return;
            }
        }
    }
    private void SwitchCurrentSeed()
    {
        if(listOfAllFruits.listOfAllInventoryFruits.Count == 1)
        {
            currentFruitInInventory = listOfAllFruits.listOfAllInventoryFruits[0];
            return;
        }

        for(int i = 0; i < listOfAllFruits.listOfAllInventoryFruits.Count; i++)
        {
            
            if(listOfAllFruits.listOfAllInventoryFruits[i] == null )
            {
                if(currentFruitInInventory == null)
                {
                    
                    continue;
                    
                }
            }


            if(listOfAllFruits.listOfAllInventoryFruits[i].Equals(currentFruitInInventory) )
            {
                
                int x = i + 1;
                for(int n = 0; n < listOfAllFruits.listOfAllInventoryFruits.Count; n++)
                {   
                    if(x >= listOfAllFruits.listOfAllInventoryFruits.Count)
                    {
                        x = 0;
                    }

                    if(listOfAllFruits.listOfAllInventoryFruits[x] != null)
                    {
                        currentFruitInInventory = listOfAllFruits.listOfAllInventoryFruits[x];

                        signalToRaise.Raise();
                        return;
                    }

                    x++;
                }
            }

        }

        currentFruitInInventory = listOfAllFruits.listOfAllInventoryFruits[0];
    }



}
