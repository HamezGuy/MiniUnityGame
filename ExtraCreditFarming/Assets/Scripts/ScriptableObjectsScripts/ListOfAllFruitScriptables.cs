using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(menuName = "List of all Fruits")]
public class ListOfAllFruitScriptables : ScriptableObject
{
    public List<GameObject> listOfAllFruits;
}
