using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;//represent the force at which the player knockback
    public float knockTime;//how long the knockback will last

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))//if the collider is the enemy
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)//if the enemy has a rigidbody
            {
                enemy.GetComponent<Enemy>().currentState = EnemyState.stagger;
                enemy.isKinematic = false;//sets kinematic to false so that gravity can affect it
                Vector2 difference = enemy.transform.position - transform.position;//this finds the difference
                difference = difference.normalized * thrust;//normalising means it become a vecctor with a lenght of 1
                enemy.AddForce(difference, ForceMode2D.Impulse);//adds the force onto the enemy sending it back
                StartCoroutine(KnockCo(enemy));//calls the Ienumerator
                //enemy.isKinematic = true;//sets it abck to true so that other forces of gravity doesnt affect it

            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)//check if the enemey has a rigidbody
        {
            yield return new WaitForSeconds(knockTime);//waits for knockback to finish
            enemy.velocity = Vector2.zero;//sets the enmeies velocity back to 0
            enemy.isKinematic = true;//sets it abck to true so that other forces of gravity doesnt affect it
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    }

}
