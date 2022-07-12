using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(FruitTreeGenotype))]
[RequireComponent(typeof(SeedGenotype))]
public class FinalTreeHarvest : MonoBehaviour
{

    [Header("note that genotypeandphenotype is only for harvesting, use arrays for other geno/pheno")]

    //TODO hook this up with tree info scripts, should auto set up this fruit tree genotypes
    protected FruitTreeGenotype thisFruitGenotype;
    [Header("dominant trait")]
    [SerializeField] protected GameObject gameObjectToInstanciate1;
    [Header("recessive trait")]
    [SerializeField] protected GameObject gameObjectToInstanciate2;
    [Header("additive trait")]
    [SerializeField] protected GameObject gameObjectToInstanciate3;
    private SeedGenotype seedToInstanciateValues = null;
    private SeedGenotype currentSeed;


    void Start()
    {
        thisFruitGenotype = GetComponent<FruitTreeGenotype>();
        currentSeed = GetComponent<SeedGenotype>();

        if(thisFruitGenotype.treePhenotypeSize[0] == 0 && thisFruitGenotype.treePhenotypeSize[1] == 0)
        {
            this.gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
        }
    }

    private void SetSeedValues(GameObject seedToInstanciate)
    {
        seedToInstanciateValues = seedToInstanciate.GetComponent<SeedGenotype>();

        System.Array.Copy(currentSeed.genotypeColor, seedToInstanciateValues.genotypeColor, 2);
        System.Array.Copy(currentSeed.genotypeSize, seedToInstanciateValues.genotypeSize, 2); //todo check this works

        seedToInstanciateValues.seedImage = currentSeed.seedImage;
        seedToInstanciateValues.isAddative = currentSeed.isAddative;
        seedToInstanciateValues.treeGameObject = currentSeed.treeGameObject;

    }

    private GameObject SetSeedToInstanciate()
    {
        switch(currentSeed.genotypeColor[0])
        {
            case 0:
                if(currentSeed.genotypeColor[1] == 1)
                {
                    if(currentSeed.isAddative)
                    {
                        return gameObjectToInstanciate3;
                    }
                    else{
                        return gameObjectToInstanciate1;
                    }
                }
                else if(currentSeed.genotypeColor[1] == 0)
                {
                    return gameObjectToInstanciate2; //recessive trait
                }
            break;

            case 1:
                if(currentSeed.genotypeColor[1] == 1)
                {
                    
                    return gameObjectToInstanciate1;
                    
                }
                else if(currentSeed.genotypeColor[1] == 0)
                {
                    if(currentSeed.isAddative)
                    {
                        return gameObjectToInstanciate3;
                    }
                    return gameObjectToInstanciate1; //recessive trait
                }
            break;
        }
        
        Debug.Log("issue wtih instanciating gameobject");
        return null;
    }


    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("harvestTool"))
        {
            GameObject gameObjectToInstanciate = SetSeedToInstanciate();
            SetSeedValues(gameObjectToInstanciate);
            gameObjectToInstanciate = Instantiate(gameObjectToInstanciate, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.transform.gameObject);
        }
    }
}
