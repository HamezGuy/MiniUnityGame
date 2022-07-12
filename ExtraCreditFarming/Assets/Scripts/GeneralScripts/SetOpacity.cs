using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOpacity : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer[] listOfSprites;

    private bool isOpacityFull = true;
    // Start is called before the first frame update

    void Start()
    {
        listOfSprites = GetComponentsInChildren<SpriteRenderer>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        //I can customize the tags further like for reed in other classes, even changing opactiy and what not
        //I mean i can customize for edge cases with the scrying orb, but whatever
        //READ ME, a different method of doing this would be using materials, but i really don't want to do extra work when I don't have to. 
        if((collider.tag.Equals("PlayerHealth") || collider.tag.Equals("PlayerScryingOrb")) )
        {
            if(isOpacityFull)
            {
                foreach(SpriteRenderer sprite in listOfSprites)
                {
                    Color tempColor = sprite.color;
                    tempColor.a = .3f;
                    sprite.color = tempColor;
                }
                isOpacityFull = false;

            }
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if((collider.tag.Equals("PlayerHealth") || collider.tag.Equals("PlayerScryingOrb")) )
        {
            if(!isOpacityFull)
            {
                foreach(SpriteRenderer sprite in listOfSprites)
                {
                    Color tempColor = sprite.color;
                    tempColor.a = 1f;
                    sprite.color = tempColor;
                }
                isOpacityFull = true;
            }
        }
    }
}
