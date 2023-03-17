using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Enemy
{
    public Transform target;//the player is the target
    public float chaseRadius;//the radisu at which the rat chases the player
    public float attackRadius;//the radius at which the rat attacks the player
    public Transform homPosition;//if the target moves out of the radius it will go back to its original position

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;//looks just for the position of the gameobject with the tag player
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius 
           && Vector3.Distance(target.position, transform.position) > attackRadius)// if the player is in the enemeies chase radius
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);//the enemey will move towardss the player
        }
    }
}
