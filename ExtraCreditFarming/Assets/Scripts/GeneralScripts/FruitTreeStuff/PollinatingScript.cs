using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IsPollonatedBool))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(FruitTreeGenotype))]

[RequireComponent(typeof(SeedGenotype))]
public class PollinatingScript : MonoBehaviour
{
    private FruitTreeGenotype fruitTreeCurrent;

    [Header("note this is a scriptable class, so don't actually need to access pollon stick script")]
    [SerializeField] private GenotypeAndPhenotypeScriptable genotypeOnStick;
    [SerializeField] private BooleanScriptable isStickPollonated;
    private IsPollonatedBool isPollonated;

    private int[] newArray = new int[2];
    private int[] newArraySize = new int[2];
    //note i put in seed stuff after so its a little janky
    private SeedGenotype seedGenotype;

    void Start()
    {
        fruitTreeCurrent = GetComponent<FruitTreeGenotype>();

        isPollonated = GetComponent<IsPollonatedBool>();
        seedGenotype = GetComponent<SeedGenotype>();
    }

    private void crossMultiply()
    {
        if(isPollonated.isReadyToPollonate == false)
        {
            return;
        }
        if(isStickPollonated.booleanValue == false)
        {
            //TODO raise signal saying that tree is
            return;
        }
        if(!genotypeOnStick.currentFruitTree.Equals(fruitTreeCurrent.currentFruitTree))
        {
            //TODO raise signal to say wrong type of tree
            return;
        }
        crossMultiplyHelperGenotype(0);
        crossMultiplyHelperGenotype(1);
        crossMultiplyHelperGenotypeSize(0);
        crossMultiplyHelperGenotypeSize(1);

        seedGenotype.currentFruitTree = fruitTreeCurrent.currentFruitTree;

        seedGenotype.isAddative = fruitTreeCurrent.isAddative;
        

        isPollonated.isPollonated = true;
    }

    private void pollonateStick()
    {
        isStickPollonated.booleanValue = true;
        genotypeOnStick.genotypeColor[0] = fruitTreeCurrent.treePhenotypeColor[0];
        genotypeOnStick.genotypeColor[1] = fruitTreeCurrent.treePhenotypeColor[1];
        genotypeOnStick.genotypeSize[0] = fruitTreeCurrent.treePhenotypeSize[0];
        genotypeOnStick.genotypeSize[1] = fruitTreeCurrent.treePhenotypeSize[1];

        genotypeOnStick.currentFruitTree = fruitTreeCurrent.currentFruitTree;
        genotypeOnStick.isAddative = fruitTreeCurrent.isAddative; 
    }

    //i mean its bad for stride but whatever
    private void crossMultiplyHelperGenotype(int i)
    {
        float tempInt = Random.Range(0, 4);
        
        if(tempInt <= 1)
        {
            newArray[i] = fruitTreeCurrent.treePhenotypeColor[0];
            seedGenotype.genotypeColor[i] = newArray[i];
            return;
        }
        else if(tempInt <= 2)
        {
            newArray[i] = fruitTreeCurrent.treePhenotypeColor[1];
            seedGenotype.genotypeColor[i] = newArray[i];
            return;
        }
        else if(tempInt <= 3)
        {
            newArray[i] = genotypeOnStick.genotypeColor[0];
            seedGenotype.genotypeColor[i] = newArray[i];
            return;
        }
        else if(tempInt <= 4){
            newArray[i] = genotypeOnStick.genotypeColor[1];
            seedGenotype.genotypeColor[i] = newArray[i];
            return;
        }
        print("error, reached end of crossmultiplyhelpergenotype without reaching a value");
    }

    private void crossMultiplyHelperGenotypeSize(int i)
    {
        float tempInt = Random.Range(0, 4);
        
        if(tempInt <= 1)
        {
            newArraySize[i] = fruitTreeCurrent.treePhenotypeSize[0];
            seedGenotype.genotypeSize[i] = newArraySize[i];
            return;
        }
        else if(tempInt <= 2)
        {
            newArraySize[i] = fruitTreeCurrent.treePhenotypeSize[1];
            seedGenotype.genotypeSize[i] = newArraySize[i];
            return;
        }
        else if(tempInt <= 3)
        {
            newArraySize[i] = genotypeOnStick.genotypeSize[0];
            seedGenotype.genotypeSize[i] = newArraySize[i];
            return;
        }
        else if(tempInt <= 4){
            newArraySize[i] = genotypeOnStick.genotypeSize[1];
            seedGenotype.genotypeSize[i] = newArraySize[i];
            return;
        }
        print("error, reached end of crossmultiplyhelpergenotypesize without reaching a value");
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if(isPollonated.isReadyToPollonate == false)
        {
            return;
        }
        if(isStickPollonated.booleanValue == false)
        {
            //TODO raise signal saying that tree is
            return;
        }
        if(other.tag.Equals("pollonStick"))
        {
            crossMultiply();
            Debug.Log("is pollonating");
        }
    }
}
