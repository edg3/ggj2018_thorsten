using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var pos = transform.position;
        pos.x -= 0.097f;

        // TODO: Error here is the numbers dont actually completely fit, 30.1 is a tiny bit off
        //        - was slightly to annoyed to complete finding the actual number, 30.1 closer than 30
        //        - similarly hence not pulling it into NumberSets

        if (pos.x <= (-6250/100.0 - 30.1))
        {
            pos.x = (float)(18750/100.0 - 30.1);
        }

        transform.position = pos;
    }
}
