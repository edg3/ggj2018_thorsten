using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScoring : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var pos = transform.position;

        pos.x -= 0.095f;

        if (pos.x <= -19)
        {
            pos.x = 17 + Mathf.Round(Random.value * 8);
            pos.y = 6f - 3.3f + Mathf.Round(Random.value * 2) - 1f;

            if (Random.value * 100 > 85)
            {
                var o = Object.Instantiate(this);
                o.Update();
            }
        }

        transform.position = pos;
        
        var dist = Mathf.Sqrt((pos.x - PlayerPhysics.pos_x_track) * (pos.x - PlayerPhysics.pos_x_track) + (pos.y - PlayerPhysics.pos_y_track) * (pos.y - PlayerPhysics.pos_y_track));
        if (dist < 0) dist = -dist;

        if (dist < 0.27f)
        {
            PlayerPhysics.points -= 1;
        }
    }
}
