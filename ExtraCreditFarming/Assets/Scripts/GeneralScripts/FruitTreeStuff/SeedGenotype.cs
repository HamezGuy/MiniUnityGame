using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class SeedGenotype : MonoBehaviour
{
    [Header("leave all this blank, hide in inspector after testing")]
    public int[] genotypeColor = new int[2];
    public int[] genotypeSize = new int[2];
    public AllFruitTrees currentFruitTree;
    public bool isAddative = false; 
    public Sprite seedImage;

    public GameObject treeGameObject;

    public SeedGenotype(int[] genotypeColorParam, int[] genotypeSizeParam, AllFruitTrees currentFruitTreeParam, bool isAddativeParam, Sprite seedImageParam, GameObject treeGameObjectParam)
    {
        genotypeColor = genotypeColorParam;
        genotypeSize = genotypeSizeParam;
        currentFruitTree = currentFruitTreeParam;
        isAddative = isAddativeParam;
        seedImage = seedImageParam;
        treeGameObject = treeGameObjectParam;
    }
}
