using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

//yes i know its really bad pracitce to have scripts linked to each other, but i already have a decent setup in my other game and this one is literally testing
public class PlayerMovement : MonoBehaviour
{
        [SerializeField] protected Animator animator;
        public PlayerStateEnum playerState;
        
        [SerializeField] protected Rigidbody2D myRigidbody;
        [SerializeField] protected float movementSpeed;

        public Vector2 tempMovement; 
    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerStateEnum.idle;
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void FixedUpdate()
    {
        if(playerState.Equals(PlayerStateEnum.walking) || playerState.Equals(PlayerStateEnum.idle) && playerState != (PlayerStateEnum.planting))
        {
            UpdateAnimationAndMove();
        }
    }

    protected void HandleMovement()
    {
        tempMovement = Vector2.zero; 
        tempMovement.x = Input.GetAxisRaw("Horizontal");
        tempMovement.y = Input.GetAxisRaw("Vertical");

    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + (Vector3) tempMovement.normalized * movementSpeed * Time.deltaTime); 
        
    }

    void UpdateAnimationAndMove(){
        
        if(tempMovement != Vector2.zero)
        {
            MoveCharacter();
            //imperative the rounding is after movecharacter so it doesn't tempMovement the direction our character moves. 
            tempMovement.x = Mathf.Round(tempMovement.x);
            tempMovement.y = Mathf.Round(tempMovement.y);
            animator.SetFloat("moveX", tempMovement.x);
            animator.SetFloat("moveY", tempMovement.y);
            animator.SetBool("isWalking", true);
            
        }else{
            animator.SetBool("isWalking", false);
        }
    }
}
