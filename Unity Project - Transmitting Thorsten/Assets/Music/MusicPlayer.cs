using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] music = new AudioClip[1];

	// Use this for initialization
	void Start () {
        //var a = GetComponent<AudioSource>();
        //a.volume = 0.5f;
        //a.clip = music[(int)(Random.value * 51)];
        //a.Play();
	}
	
	// Update is called once per frame
	void Update () {
        //var a = GetComponent<AudioSource>();
        //if (!a.isPlaying)
        //{
        //    a.clip = music[(int)(Random.value * 51)];
        //    a.Play();
        //}
    }
}
