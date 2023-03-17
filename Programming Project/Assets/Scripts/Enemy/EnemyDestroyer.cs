using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
	public float destroyTime = 3.0f;//time inbetween each destory

    private RandomSpawner RS;//creates a conncetion to the RandomSpawner script
    public Transform mySpawnPoint;
    //this is used to pass the transform of the spawnPoint which a particular enemy has been gone over 

    //use this for initialization
    void Start()
    {
        RS = GameObject.Find("Random Enemy Spawner").GetComponent<RandomSpawner>();
        //this finds the gameobject and has acces to it
        //StartCoroutine(DestroyMe());//starts the IEnumurater DestoryMe
    }
    void Update()
    {

    }

    IEnumerator DestroyMe()//debugging purposes makes space in the lists so that it can spawn a new enemy
    {
        yield return new WaitForSeconds(destroyTime);//waits the duration of the destory time or else it gets destroyed instantly

        for(int i = 0; i<RS.spawnPoints.Length; i++)//loops through the spawn points anc checks what position the nemey is at 
        {
            if(RS.spawnPoints[i] == mySpawnPoint)//if the sapwnpoint it is in, is the same as the item as the already spwned enemy
            {
                RS.possibleSpawns.Add(RS.spawnPoints[i]);//passes the parameter back to the possibleSpawns list
            }    
        }
        Destroy(gameObject);
    }      
}