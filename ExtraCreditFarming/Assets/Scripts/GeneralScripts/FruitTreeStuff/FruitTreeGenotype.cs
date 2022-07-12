using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitTreeGenotype : MonoBehaviour
{
    
    [Tooltip("so this is basically just a set of values")
    ][Header("these values should be filled in")]
    public int[] treePhenotypeColor = new int[2];
    public int[] treePhenotypeSize = new int[2];
    public AllFruitTrees currentFruitTree;
    public bool isAddative = false;

    public Sprite thisSeedImage;

}
