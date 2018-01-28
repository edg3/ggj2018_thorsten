using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum DanceStates
{
    NotDancing,
    JumpDance
}

public class PlayerPhysics : MonoBehaviour
{
    float timer = -1f;
    float gameTime = 0f;
    private DateTime startTime;
    float danceTime = 0f;

    public static int points = 0;
    public static float pos_x_track, pos_y_track;
    public static float pos_x_default;

    public static float initialZ;
    public static DanceStates dancingState = DanceStates.NotDancing;

    public static Vector3 whereIam;

    public static DateTime whenLastCoin;

    // Use this for initialization
    void Start()
    {
        startTime = System.DateTime.Now;
        points = 0;

        pos_x_default = transform.position.x;

        initialZ = transform.rotation.z;

        whenLastCoin = System.DateTime.Now;
    }

    private void OnGUI()
    {
        // Wasnt really time for changing this overlay since the time was mostly spent on minimal physics errors (from changing the size of 2D boxes)
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Timer: " + gameTime.ToString() + "\nScore: " + points.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        var body = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        var hit = new RaycastHit2D();
        var v = new Vector2(body.position.x, body.position.y - 1.56f); //1.628182 instead of 1.1f from before | use Debug.logger to log in tests | had to move it from the 1.62~ aswell
        hit = Physics2D.Raycast(v, Vector2.down);

        if ((hit.distance < 0.17f) && (hit.collider != null))
        {
            if (timer < 0)
            {
                PotentialJump();
            }
        }

        if (timer > 0)
        {
            timer -= 1f;
            if (timer <= 0)
                timer = -1f;
        }

        // TODO: work out the actual good "level" for this, needs adjustments for blatant physics problems...
        if (body.position.y < -3.3f)
        {
            SceneManager.LoadScene("End");
        }
        var asdf = (System.DateTime.Now - startTime);
        gameTime = (float)((asdf.TotalMilliseconds) / 1000f);

        switch (dancingState)
        {
            case DanceStates.NotDancing:
                {
                    var a = Input.GetKeyDown(KeyCode.A);
                    if ((a) && (danceTime <= 0))
                    {
                        dancingState = (DanceStates)(1 + (UnityEngine.Random.value * 1)); // Note to seld dont leave random toward extra higher value here by accident
                        danceTime = 15f;
                    }
                } break;
            case DanceStates.JumpDance:
                {
                    if (danceTime > 2.5f)
                    {
                        body.AddForce(new Vector2(0, 6));
                    }
                    danceTime -= 0.25f;
                } break;
        }

        if (danceTime <= 0)
        {
            dancingState = DanceStates.NotDancing;
        }

        pos_x_track = transform.position.x;
        pos_y_track = transform.position.y;

        // TODO: below physics also have a mish mash of errors
        //        - e.g. when jumping you will see it binds movement to top of roof when it shouldnt and thats new from this code

        //fix moving off screen from physics
        var fix = pos_x_default - pos_x_track;
        if (fix != 0)
        {
            var pos = transform.position;
            pos.x = pos_x_default;
            transform.position = pos;
        }

        //fix rotation from physics
        var rot = transform.rotation;
        if (rot.z != initialZ)
        {
            rot.z = initialZ;
            transform.rotation = rot;
        }

        whereIam = this.transform.position;

        Debug.logger.Log((DateTime.Now - whenLastCoin).TotalSeconds.ToString());
        if ((DateTime.Now - whenLastCoin).TotalSeconds > 1.71f) // feels like the good choice for "losing" coins score
        {
            whenLastCoin = DateTime.Now;
            points -= 1;
            
        }

        if (points < -99)
        {
            SceneManager.LoadScene("End");
        }

        if (points > 99)
        {
            SceneManager.LoadScene("Win");
        }

        var a123 = Vector3.zero;
        var keptPosition = new Vector3();
        keptPosition.x = this.transform.position.x;
        keptPosition.y = this.transform.position.y;
        keptPosition.z = -10f;
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, keptPosition, ref a123, 0.001f);
    }

    void PotentialJump()
    {
        // TODO: Something in this (and use of it) is dead as a doornail, consider you jump then "dance" then cant jump/dance ever again
        //        - most likely a slightly incorrect word/number somewhere
        //        - likely could also be seen as a rounding error in "if" somewhere
        if (Input.GetKeyDown(KeyCode.Space) && (dancingState == DanceStates.NotDancing))
        {
            var body = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            body.AddForce(new Vector2(0, 312));
            timer = 3f;
        }
    }
}
