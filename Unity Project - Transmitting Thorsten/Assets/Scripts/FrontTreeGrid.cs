using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontTreeGrid : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Resprite();
	}

    public void Resprite()
    {
        var doWeRotate = NumberSets.Reference.GetFiftyFiftyRotationAngle();
        var rot = transform.rotation;
        if (doWeRotate)
        {
            rot.y = 0;
        }
        else
        {
            rot.y = 180;
        }
        transform.rotation = rot;

        // Do we still want vertical rotation?
        //  - if yes will be around "z" but same as above
    }
	
	// Update is called once per frame
	void Update () {
        var pos = transform.position;

        pos.x -= NumberSets.Reference.defaultBabySpeed;

        if (pos.x <= NumberSets.Reference.defaultBabyMoveChangeDist)
        {
            pos.x = NumberSets.Reference.GetBabyHorizontal();
            pos.y = NumberSets.Reference.GetBabyVertical();
            Resprite();
        }

        transform.position = pos;
    }
}
