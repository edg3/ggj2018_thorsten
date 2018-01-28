using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    // Birds are at back, "baby" are still birds but are the front facing
    public class NumberSets
    {
        // Grids = width of change for the buildings
        public float defaultBuildWidth = 14.5f;
        public float[] buildingGrids
            = new float[4];

        // Grid height is the same as grids but height obviously
        public float defaultBuildHeight = -2.39f;
        public float[] buildingGridHeights
            = new float[3];

        // Grids fps movement
        public float gridMoveSpeed = 0.085f;
        public float gridCapLeft = -16;

        // Bird pos stuff
        public float defaultMinBirdHeight = -0.33f;
        public float defaultMaxBirdHeight = 1.6f;
        public float defaultBirdRearSpeed = 0.095f;
        public float defaultBirdRearMoveChangeDist = -14;

        // Front tiny bird
        public float defaultMinBabyHeight = -1f;
        public float defaultMaxBabyHeight = -4.2f; //Note this min max is swapped from the "bird"
        public float defaultBabySpeed = 0.09f;
        public float defaultBabyMoveChangeDist = -13f;

        // Point score coin
        public float defaultPointScoreSpeed = 0.095f;
        public float defaultPointScoreMoveChangeDist = -13f;

        public NumberSets()
        {
            // building grids = spaces for when we update and move the building's we walk over
            buildingGrids[0] = defaultBuildWidth + -1.5f;
            buildingGrids[1] = defaultBuildWidth + .45f;
            buildingGrids[2] = defaultBuildWidth + 0.90f;
            buildingGrids[3] = defaultBuildWidth + 1.35f;
            // Todo: find the missing link of good sizes to use

            //building grid heights are for where the building tiles are
            buildingGridHeights[0] = defaultBuildHeight - 0.75f;
            buildingGridHeights[1] = defaultBuildHeight - 0;
            buildingGridHeights[2] = defaultBuildHeight + 0.74f;
        }

        public float GetScoringCoinX()
        {
            return 14 + UnityEngine.Random.value * 7;
        }

        internal float GetScoringCoinY()
        {
            return 6f - 3.3f + Mathf.Round(UnityEngine.Random.value * 2) - 1f;
        }

        public float GetBirdHeight()
        {
            var dist = -defaultMinBirdHeight + defaultMaxBirdHeight;
            var position = UnityEngine.Random.value * dist;
            var actual_pos = defaultMaxBirdHeight - position;
            return actual_pos;
        }

        public bool GetFiftyFiftyRotationAngle()
        {
            return (UnityEngine.Random.value < 0.5f);
        }

        // This basically binds it to move a far enough distance away
        public float GetBirdHorisontal()
        {
            return 18 + UnityEngine.Random.value * 18 * 2; //Should be 32 instead of 18 potentially or its too many birds
        }

        public float GetBabyHorizontal()
        {
            return 8 + UnityEngine.Random.value * 18 * 2; //Should be 32 instead of 18 potentially or its too many birds
        }

        public float GetBabyVertical()
        {
            var dist = -defaultMaxBabyHeight - defaultMinBabyHeight;
            var position = UnityEngine.Random.value * dist;
            var actual_pos = defaultMinBirdHeight - position;
            return actual_pos;
        }

        public float GetGrid()
        {
            return buildingGrids[(int)(UnityEngine.Random.value * buildingGrids.Length)];
        }

        public float GetGridHeight()
        {
            return buildingGridHeights[(int)(UnityEngine.Random.value * buildingGridHeights.Length)];
        }

        private static NumberSets _ref;
        public static NumberSets Reference { get { if (_ref == null) { _ref = new NumberSets(); } return _ref; } }

    }
}
