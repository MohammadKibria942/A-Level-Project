using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // reference to what the camera follows (the player)
    public float smoothing; // how quickly the camera moves to the target
    public Vector2 maxPosition; // takes max of X and Y position
    public Vector2 minPosition; // takes min of X and Y position

    // Start is called before the first frame update
    void Start() {
        
    }

    void LateUpdate() {// this happens last, we want the player to move then the camera follow
        if (transform.position != target.position) //if the camera is not on the player
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            // create a targetPosition that has its own Z position so that it doesnt change and go underneath the scene

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            //Mathf.Clamp has takes in 3 arguments, the value you want to clamp, what the min is, and what the max is
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            //this takes 3 arguments, it takes the position you are currentley at, the position we want to go to, and the amount we want to cover
        }
    }
}
