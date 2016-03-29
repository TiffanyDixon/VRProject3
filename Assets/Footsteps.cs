﻿using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

	public AudioClip clip;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W))
		{
			GetComponent<AudioSource>().clip = clip;
			GetComponent<AudioSource>().Play();

		}
	}
}
