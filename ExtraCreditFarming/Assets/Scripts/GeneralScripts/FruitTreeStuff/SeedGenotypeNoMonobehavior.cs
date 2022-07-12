using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SeedGenotypeNoMonobehavior
{
    [Header("leave all this blank, hide in inspector after testing")]
    public int[] genotypeColor = new int[2];
    public int[] genotypeSize = new int[2];
    public AllFruitTrees currentFruitTree;
    public bool isAddative = false; 
    public Sprite seedImage;
    public string name;

    public GameObject treeGameObject;

    public SeedGenotypeNoMonobehavior(int[] genotypeColorParam, int[] genotypeSizeParam, AllFruitTrees currentFruitTreeParam, bool isAddativeParam, Sprite seedImageParam, GameObject treeGameObjectParam, string itemname)
    {
        genotypeColor = genotypeColorParam;
        genotypeSize = genotypeSizeParam;
        currentFruitTree = currentFruitTreeParam;
        isAddative = isAddativeParam;
        seedImage = seedImageParam;
        treeGameObject = treeGameObjectParam;
        name = itemname;
    }
}
