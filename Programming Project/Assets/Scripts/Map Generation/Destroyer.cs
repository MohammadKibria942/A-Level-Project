using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	//this once called destroys the last placed room 
	void OnTriggerEnter2D(Collider2D other){
		Destroy(other.gameObject);
		//Destroy(GameObject.FindWithTag("SpawnPoint"));
		
	}
}
