using UnityEngine;
using System.Collections;

public class Introduction : MonoBehaviour {

	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;

	private AudioSource audio;
	private bool triggered = false;

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider collide){
		if(collide.tag == "Player" && !triggered){
			triggered = true;
			PlayAudio();
		}
	}

	void PlayAudio() {
		audio.clip = clip1;
		audio.Play();

		Invoke ("PlayAudio2", 5);
		Invoke ("PlayAudio3", 10);
	}

	void PlayAudio2() {
		audio.clip = clip2;
		audio.Play();
	}

	void PlayAudio3() {
		audio.clip = clip3;
		audio.Play();
	}
}
