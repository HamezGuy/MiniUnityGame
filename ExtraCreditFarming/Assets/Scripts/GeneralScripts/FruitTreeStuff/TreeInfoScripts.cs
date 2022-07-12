using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SeedGenotype))]
[RequireComponent(typeof(IsPollonatedBool))]
public class TreeInfoScripts : MonoBehaviour
{
    [Header("note, do not put this script on the last tree prefab")]
    protected IsPollonatedBool isPollonated;
    [SerializeField] protected GameObject nextPlantToInstanciate;

    [SerializeField] protected bool needsPollenForNextStep; //set isReadyToPollonate in isPollonatedBool to this is readytopollonate

    protected float timeInstanciated = 0;

    protected FruitTreeGenotype nextFruitTreeGenotype;
    protected FruitTreeGenotype thisFruitTreeGenotype;
    [SerializeField] protected float timeToGrow = 10;
    protected SeedGenotype seedGenotype;
    private SeedGenotype nextSeedGenotype = null;

    void Awake()
    {
        thisFruitTreeGenotype = GetComponent<FruitTreeGenotype>();
        seedGenotype = GetComponent<SeedGenotype>();
        isPollonated = GetComponent<IsPollonatedBool>();
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        

        //note there is no additive for tree size
        if(thisFruitTreeGenotype.treePhenotypeSize[0] == 0 && thisFruitTreeGenotype.treePhenotypeSize[1] == 0)
        {
            this.gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
        }
        InvokeRepeating("CheckIfTreeIsGrowing", 1f, 1f);
    }
    protected virtual void CheckIfTreeIsGrowing()
    {
        if(needsPollenForNextStep)
        {
            if(!isPollonated.isReadyToPollonate)
            {
                if(timeInstanciated >= timeToGrow)
                {
                    isPollonated.isReadyToPollonate = true;
                }
            }
            if(!isPollonated.isPollonated)
            {
                return;
            }
        }
        
        timeInstanciated += 1;
        

        if(timeInstanciated >= timeToGrow)
        {
            SetGenotypeOfNextTree();
            Instantiate(nextPlantToInstanciate, this.transform.position, Quaternion.identity);
            

            Destroy(this.gameObject);
        }

    }

    protected virtual void SetGenotypeOfNextTree()
    {
        thisFruitTreeGenotype = GetComponent<FruitTreeGenotype>();
        //note, next tree type should already be figured out
        nextFruitTreeGenotype = nextPlantToInstanciate.GetComponent<FruitTreeGenotype>();
        if(nextFruitTreeGenotype == null)
        {
            print("issue occured with next genotype");
            return;
        }
        nextFruitTreeGenotype.treePhenotypeColor[0] = thisFruitTreeGenotype.treePhenotypeColor[0];
        nextFruitTreeGenotype.treePhenotypeColor[1] = thisFruitTreeGenotype.treePhenotypeColor[1];
        nextFruitTreeGenotype.treePhenotypeSize[0] = thisFruitTreeGenotype.treePhenotypeSize[0];
        nextFruitTreeGenotype.treePhenotypeSize[1] = thisFruitTreeGenotype.treePhenotypeSize[1];
        nextFruitTreeGenotype.isAddative = thisFruitTreeGenotype.isAddative;
        nextFruitTreeGenotype.currentFruitTree = thisFruitTreeGenotype.currentFruitTree;
        nextFruitTreeGenotype.thisSeedImage = thisFruitTreeGenotype.thisSeedImage;
 
    }
    protected virtual void SetGenotypeOfNextSeed()
    {
        //note, next tree type should already be figured out
        nextSeedGenotype = nextPlantToInstanciate.GetComponent<SeedGenotype>();
        if(nextSeedGenotype == null)
        {
            print("issue occured with next genotype");
            return;
        }
        nextSeedGenotype.genotypeColor[0] = seedGenotype.genotypeColor[0];
        nextSeedGenotype.genotypeColor[1] = seedGenotype.genotypeColor[1];
        nextSeedGenotype.genotypeSize[0] = seedGenotype.genotypeSize[0];
        nextSeedGenotype.genotypeSize[1] = seedGenotype.genotypeSize[1];
        nextSeedGenotype.isAddative = seedGenotype.isAddative;
        nextSeedGenotype.currentFruitTree = seedGenotype.currentFruitTree;
        nextSeedGenotype.seedImage = seedGenotype.seedImage;
        nextSeedGenotype.treeGameObject = seedGenotype.treeGameObject;
 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("harvestTool"))
        {
            Destroy(this.gameObject);
        }
    }
   
}
