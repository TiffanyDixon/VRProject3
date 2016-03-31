using UnityEngine;
using System.Collections;

public class Introduction : MonoBehaviour {

	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;

	private AudioSource audio;
	private bool triggered = false;
	private AudioSource jeers;
	private float jeersOriginalVol = .4f;
	private float jeersTargetVol = .01f;
	private bool canUpdate = true;

	void Start() {
		audio = GetComponent<AudioSource>();
		jeers = GameObject.FindGameObjectsWithTag("Jeers")[0].GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider collide){
		if(collide.tag == "Player" && !triggered){
			triggered = true;
			PlayAudio();
		}
	}

	void Update() {
		if (!canUpdate) return;
		jeers.volume = Mathf.Lerp(jeers.volume, jeersTargetVol, Time.deltaTime*3f);

		if (Mathf.Abs(jeers.volume - jeersTargetVol) < 0.05f) {
			canUpdate = false;
		}
	}

	void PlayAudio() {
		canUpdate = true;
		
		Invoke ("PlayAudio1", 1);
		Invoke ("PlayAudio2", 5);
		Invoke ("PlayAudio3", 10);
		Invoke ("ReturnJeers", 15);
	}

	void PlayAudio1() {
		audio.clip = clip1;
		audio.Play();
	}

	void PlayAudio2() {
		audio.clip = clip2;
		audio.Play();
	}

	void PlayAudio3() {
		audio.clip = clip3;
		audio.Play();
	}

	void ReturnJeers() {
		jeersTargetVol = jeersOriginalVol;
		canUpdate = true;
	}
}
