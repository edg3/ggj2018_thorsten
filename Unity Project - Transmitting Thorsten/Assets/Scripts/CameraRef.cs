using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRef : MonoBehaviour {
    
    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        // Camera stopped moving, damn? I came to check if the code wasnt accidentally deleted
        Debug.logger.Log(transform.position.ToString() + " goes to " + PlayerPhysics.whereIam.ToString());
    }
}
