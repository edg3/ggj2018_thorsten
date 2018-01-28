using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScoringCoin : MonoBehaviour {
    private bool hasGiven = false;

    public static int PointScoringCoinTotal = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var pos = transform.position;

        pos.x -= NumberSets.Reference.defaultPointScoreSpeed;

        if (pos.x <= NumberSets.Reference.defaultPointScoreMoveChangeDist)
        {
            hasGiven = false;

            pos.x = NumberSets.Reference.GetScoringCoinX();
            pos.y = NumberSets.Reference.GetScoringCoinY();

            if ((Random.value > 0.9f) && (PointScoringCoinTotal < 7))
            {
                var o = Object.Instantiate(this);
                o.Update();
                PointScoringCoinTotal += 1;
            }
            
        }

        transform.position = pos;

        //var body = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        var dist = Mathf.Sqrt((pos.x - PlayerPhysics.pos_x_track) * (pos.x - PlayerPhysics.pos_x_track) + (pos.y - PlayerPhysics.pos_y_track) * (pos.y - PlayerPhysics.pos_y_track));
        if (dist < 0) dist = -dist;

        if (dist < 0.75f) //note this needs reference changes and number changes, see below
        {
            if (!hasGiven)
            {
                if (PlayerPhysics.dancingState == DanceStates.NotDancing)
                {
                    PlayerPhysics.points += 1;
                }
                else
                {
                    PlayerPhysics.points += 3;
                }

                PlayerPhysics.whenLastCoin = System.DateTime.Now;
                hasGiven = true;
            }
        }
        // Do we want this on the face? Technically that it should be bound to neck and head since it is food?
        // Similarly it should potentially not be circular?
        //  - would be quick and easy to make a box I suppose
        // I also don't know what to use/do for loss condition anymore? Besides the slow time I havent worked it out
    }
}
