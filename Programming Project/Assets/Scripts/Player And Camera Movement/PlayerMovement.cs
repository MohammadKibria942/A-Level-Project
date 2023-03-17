using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState//controls the different states, works similar to a boolean
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;//this is a referance to the PlayerState
    public float speed = 5f;// this determines how fast the player moves, i made it public so i can change it in the editor
    private Rigidbody2D myRigidbody;// then i need to reference the sprites rigidbody, this is privet becuase it doesnt change
    private Vector3 change;// this controls how much the players position changes
    private Animator animator;// this references the animator component, this is private because it doesnt change

    public int veiwDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();//completes the reference to the animator component
        myRigidbody = GetComponent<Rigidbody2D>();//this completes the reference to the rigidbody
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;//this resets how much the player has changed
        change.x = Input.GetAxisRaw("Horizontal");// * Time.deltaTime * speed;//this gets the horizontal input
        change.y = Input.GetAxisRaw("Vertical");// * Time.deltaTime * speed;//this gets the vertical input
        if(change !=Vector3.zero)
        {
            transform.Translate(new Vector3(change.x, change.y));
        }
        MoveCharacter();
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk)//this is so its dependant on the first if statement
        {
            updateAnimationAndMove();//calls the function
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);//sets the attaacking animation to true, starting the attack animation
        currentState = PlayerState.attack;//puts the player into the attack state
        yield return null;//waits 1 frame
        animator.SetBool("attacking", false);//sets attacking abck to false so it doesnt keep on repeating
        yield return new WaitForSeconds(0.33f);//waits 0.33 seconds for the animation to end
        currentState = PlayerState.walk;//sets the current state back to walking
    }


    void updateAnimationAndMove()
    {
        if (change != Vector3.zero)//if we are moving
        {
            MoveCharacter();
            transform.Translate(new Vector3(change.x, change.y));
            animator.SetFloat("moveX", change.x);//this sets the moveX to whatever the change.x is playing the animation 
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);//this sets moving to true when we are moving
        }
        else
        {   
            animator.SetBool("moving", false);//sets to false 
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }
}