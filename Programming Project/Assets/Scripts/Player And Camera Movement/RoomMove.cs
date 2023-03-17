using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour {

    public Vector2 cameraChange; //changes how much the camera moves
    public Vector3 playerChange; //changes how much the player moves
    private CameraMovement cam;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other)// the argument of collider and calls it 'other'
    {
        if(other.CompareTag("Player"))// this checks to see if the player is in the trigger zone
        {//if it is true access the camera and change the offset of the camera
            cam.minPosition += cameraChange;//gets the camera min position and adds how much the camera moves
            cam.maxPosition += cameraChange;//gets the camera max position and adds how much the camera moves
            other.transform.position += playerChange;//this moves the player to the next room by adding the playerChange to the players current position
        }
    }
}
