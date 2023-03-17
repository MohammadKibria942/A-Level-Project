using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	//each of these  game objects holds the prefabs for the corrosponding room
	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	public float waitTime;
	private bool spawnedExit;
	public GameObject exit;
	private Vector3 lastPos;
	private GameObject exitPos;

	void Update(){
		//this checks to see if an exit has been spawned or not
		if(waitTime <= 0 && spawnedExit == false){
			//then it places all rooms generated into a list
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
					//then spawns the exit on the last room spawned
					Instantiate(exit, rooms[i].transform.position, Quaternion.identity);
					//spawns the exit room with no rotation at the last spawned room
					lastPos = rooms[i].transform.position;

					spawnedExit = true;
					//spawnedExit = true so that it doesnt spawn another exit
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
