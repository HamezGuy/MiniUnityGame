using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Inventory Objects")]
public class InventoryObjects : ScriptableObject
{
    public int numberHeld;
    public Image thisImage;
    public AllObjectTypesEnum typeOfObject;
    public GameObject gameObjectToInstanciate;
}
