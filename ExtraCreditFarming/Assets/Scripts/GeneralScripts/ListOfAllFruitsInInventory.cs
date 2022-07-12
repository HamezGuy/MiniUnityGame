using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListOfAllFruitsInInventory : MonoBehaviour
{
   [SerializeField] public List<SeedGenotypeNoMonobehavior> listOfAllInventoryFruits;

   //todo to add to list and gain object permiance I have the thing here, and add to it here

    //this allows storage on local class, so it isn't deleted by garbage collector when different class is destroyed
   public void AddToList(SeedGenotype fruitToAdd)
   {
       SeedGenotypeNoMonobehavior newSeed = new SeedGenotypeNoMonobehavior(fruitToAdd.genotypeColor, fruitToAdd.genotypeSize, fruitToAdd.currentFruitTree, fruitToAdd.isAddative
       ,fruitToAdd.seedImage, fruitToAdd.treeGameObject, fruitToAdd.name);
       /*Debug.Log(newSeed);
       newSeed.name = "setin";
       Debug.Log(newSeed.name);
       Debug.Log(newSeed);
       for(int i = 0; i < 2; i++)
       {
           newSeed.genotypeColor[i] = fruitToAdd.genotypeColor[i];
       }

       for(int i = 0; i < 2; i++)
       {
           newSeed.genotypeSize[i] = fruitToAdd.genotypeSize[i];
       }

       newSeed.isAddative = fruitToAdd.isAddative;
       newSeed.currentFruitTree = fruitToAdd.currentFruitTree;
       newSeed.seedImage = fruitToAdd.seedImage;
       newSeed.treeGameObject = fruitToAdd.treeGameObject;
       */
       listOfAllInventoryFruits.Add(newSeed);
       
   }
}
