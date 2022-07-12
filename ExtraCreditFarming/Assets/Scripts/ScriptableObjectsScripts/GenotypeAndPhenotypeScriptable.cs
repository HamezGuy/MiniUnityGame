using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "genotype and phenotype scriptable ",menuName = "genotype and phenotype scriptable")]
public class GenotypeAndPhenotypeScriptable : ScriptableObject
{
    public int[] genotypeColor = new int[2];
    public int[] genotypeSize = new int[2];
    public AllFruitTrees currentFruitTree;
    public bool isAddative = false; 


}
