using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SeedGenotype))]


[System.Serializable]
public class CropToInventory : MonoBehaviour
{
    private GameObject player;
    private ListOfAllFruitsInInventory playerInventoryFruits;
    private bool isPlayerInRange = false;
    [SerializeField] protected int numberOfItemsToAdd;
    [SerializeField] protected Signal signalToRaise;
    protected SeedGenotype seedToAddValues;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        playerInventoryFruits = player.GetComponent<ListOfAllFruitsInInventory>();

        seedToAddValues = GetComponent<SeedGenotype>();
    }

    // Update is called once per frame
    void Update()
    {
        //todo put interact keyword
        if(Input.GetButtonDown("interact"))
        {
            if(isPlayerInRange)
            {
                AddItemToInventory();
            }
        }
    }

    private void AddItemToInventory()
    {
        playerInventoryFruits.AddToList(seedToAddValues);
        signalToRaise.Raise();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag.Equals("player"))
        {
            isPlayerInRange = false;
        }
    }
}
