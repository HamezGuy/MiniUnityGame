using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShowImage : MonoBehaviour
{
    [SerializeField] CurrentlyEquippedSeed currrentlyEquippedSeed;
    [SerializeField] Image imageToShow;
    private Sprite sprite;
    private SeedGenotypeNoMonobehavior seedGenotypeNoMonobehavior;
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Update()
    {
        SetSeedImage();
    }

    public void SetSeedImage()
    {
        if(currrentlyEquippedSeed.currentFruitInInventory == null)
        {
            return;
        }

        

        seedGenotypeNoMonobehavior = currrentlyEquippedSeed.currentFruitInInventory;
        text.text = ("Genotype + Phenotype " + currrentlyEquippedSeed.currentFruitInInventory.genotypeColor[0] + currrentlyEquippedSeed.currentFruitInInventory.genotypeColor[1]
        + " " + currrentlyEquippedSeed.currentFruitInInventory.genotypeSize[0] + currrentlyEquippedSeed.currentFruitInInventory.genotypeSize[1]); 
        sprite = seedGenotypeNoMonobehavior.seedImage;
        imageToShow.sprite = sprite;
    }

    
}
