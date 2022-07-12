using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovementModifyEnum;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeToAttack = .5f;
    bool isAttacking =false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("attack"))
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        if(isAttacking)
        {
            yield break;
        }
        animator.SetBool("isAttacking", true);
        isAttacking = true;
        yield return new WaitForSeconds(timeToAttack);
        animator.SetBool("isAttacking", false);
        isAttacking = false;
    }
}
