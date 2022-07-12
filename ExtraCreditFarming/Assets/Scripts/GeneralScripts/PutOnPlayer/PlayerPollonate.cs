using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPollonate : MonoBehaviour
{
    [SerializeField] protected Animator animator;

    [SerializeField] float pollonateTime;
    [SerializeField] private PlayerMovement playerMovement;
    private bool isPollonating = false;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("pollonate"))
        {
            if(!isPollonating)
            {
                StartCoroutine(PollonateItem());
            }
        }
    }

    public IEnumerator PollonateItem()
    {
        if(isPollonating)
        {
            yield break;
        }
        
        animator.SetBool("isPollonating", true);
        isPollonating = true;
        yield return new WaitForSeconds(pollonateTime);

        isPollonating = false;
        animator.SetBool("isPollonating", false);


    }
}
