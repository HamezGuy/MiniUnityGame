using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CurrentlyEquippedSeed))]
public class PlantCurrentSeed : MonoBehaviour
{
    [SerializeField] CurrentlyEquippedSeed currentlyEquippedSeed;
    [Header("this should be the same variable as in dirt object")]
    [SerializeField] PositionAndOccupationScriptable locationAndAbilityToPlant;
    [SerializeField] BooleanScriptable canPlantHere;
    protected bool isOccupied; //find out on dirstscript what it is
    [SerializeField] protected Animator animator;
    [SerializeField] private PlayerMovement playerMovementScript; //yeah yeah i know its bad, i could always put a script with the value buts its literally extra credit work.
    [SerializeField] protected Signal signalToRaise;

    // Start is called before the first frame update
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("interact"))
        {

            if(canPlantHere.booleanValue == true)
            {
                PlantSeed();
            }
        }
    }

    private void PlantSeed()
    {
        

        isOccupied = locationAndAbilityToPlant.isOccupied;
        

        if(isOccupied)
        {
            Debug.Log("can't plant is occupied");
            //TODO RAISE SIGNAL
            return;
        }

        if(!currentlyEquippedSeed.currentFruitInInventory.treeGameObject)
        {
            Debug.Log("can't plant nothing there");
            //TODO signal raise
            return;
        }

        Debug.Log("instanciating object");
        Vector3 tempVector = new Vector3(locationAndAbilityToPlant.xLocation, locationAndAbilityToPlant.yLocation, 0);
        
        GameObject gameObjectToInstanciate = currentlyEquippedSeed.currentFruitInInventory.treeGameObject;
        SetValuesInGameobject(gameObjectToInstanciate);

        Instantiate(gameObjectToInstanciate, tempVector, Quaternion.identity); //don't set parent or any overloads

        StartCoroutine(PlantingCoroutine());
        //TODO IMPORTANT, RAISE SIGNAL THAT SETS THE IS OCCUPIED ON OBJECT TO TRUE;. 
        signalToRaise.Raise();

        return;
    }


    private void SetValuesInGameobject(GameObject gameObject)
    {
        FruitTreeGenotype setGenotype = gameObject.GetComponent<FruitTreeGenotype>();

        System.Array.Copy(currentlyEquippedSeed.currentFruitInInventory.genotypeColor, setGenotype.treePhenotypeColor, 2);
        System.Array.Copy(currentlyEquippedSeed.currentFruitInInventory.genotypeSize, setGenotype.treePhenotypeSize, 2);
        setGenotype.currentFruitTree = currentlyEquippedSeed.currentFruitInInventory.currentFruitTree;
        setGenotype.isAddative = currentlyEquippedSeed.currentFruitInInventory.isAddative;
    }

    private void SetAnimator(bool valueToSet)
    {
        animator.SetBool("isPlanting", valueToSet);
    }

    private IEnumerator PlantingCoroutine()
    {
        SetAnimator(true);
        playerMovementScript.playerState = PlayerStateEnum.planting;
        yield return new WaitForSeconds(.25f);
        SetAnimator(false);
        playerMovementScript.playerState = PlayerStateEnum.idle;
        yield return null;
    }
}
