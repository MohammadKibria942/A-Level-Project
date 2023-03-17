using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;//this holds the next scene to load

    public void OnTriggerEnter2D(Collider2D other)// this creates a collider called other, which triggers whatever is in the function
    {
        if(other.CompareTag("Player") && !other.isTrigger)//if the collider has the 'Player' tag
        {
            SceneManager.LoadScene(sceneToLoad);//load the next scene
        }
    }
}
