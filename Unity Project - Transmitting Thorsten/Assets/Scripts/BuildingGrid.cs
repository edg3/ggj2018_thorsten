using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGrid : MonoBehaviour {

    public static List<BuildingGrid> listOfBuildings;

	// Use this for initialization
	void Start () {
        if (listOfBuildings == null)
            listOfBuildings = new List<BuildingGrid>();

        listOfBuildings.Add(this);
	}

	// Update is called once per frame
	void Update () {
        var pos = transform.position;

        pos.x -= NumberSets.Reference.gridMoveSpeed;

        if (pos.x <= NumberSets.Reference.gridCapLeft)
        {
            pos.y = NumberSets.Reference.GetGridHeight();
            pos.x = NumberSets.Reference.GetGrid();
        }

        transform.position = pos;
    }

    
}
