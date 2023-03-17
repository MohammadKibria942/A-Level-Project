using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;//an array of transforms that holds all the spawn points
    public GameObject[] enemyPrefabs;//gameObject array where it takes several types of enemies
    public float spawnTime = 1.5f;//spawn delay time, time inbetween each spawn

    public List<Transform> possibleSpawns = new List<Transform>();
    //create a list of type transform that holds all possible spawn points but doesnt affect the spawnPoints array
    //updates when a specific spawn point is taken by an enemy

    //use this for initialization
    void Start()
    {
        //fill possible spawns
        for (int i = 0; i < spawnPoints.Length; i++)//this fills the possibleSpawns array with all the spawnPoints
        {
            possibleSpawns.Add(spawnPoints[i]);
        }

        //start spawning
        InvokeRepeating("SpawnItems", spawnTime, spawnTime);
        //repeats the SpawnItems function starting at the spawnTime and after every spawnTime
         
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnItems()
    {
        if (possibleSpawns.Count > 0)//if the spawnpoints are not taken then start spawning
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);//randomly chooses the enemy to spawn
            int randSpawnPoint = Random.Range(0, possibleSpawns.Count);//randomly chooses the spawnpoint



            GameObject NewEnemy = Instantiate(enemyPrefabs[randEnemy], possibleSpawns[randSpawnPoint].position, transform.rotation) as GameObject;
            //then instantiate the chosen enemy at the chosen spawnpoint with the the same rotation
            NewEnemy.GetComponent<EnemyDestroyer>().mySpawnPoint = possibleSpawns[randSpawnPoint];//this gets acces to the destroy script

            possibleSpawns.RemoveAt(randSpawnPoint);
        }
    }
}