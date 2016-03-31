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

	private float minIntensity = 0.5f;
	private float maxIntensity = 1f;
	private float duration = 1f;

	void Start() {
		audio = GetComponent<AudioSource>();
		jeers = GameObject.FindGameObjectsWithTag("Jeers")[0].GetComponent<AudioSource>();

		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Emissive_Guardian")) {
			Light light = obj.AddComponent<Light>();
		}

		SetMidtoneIntensity(0f);
		SetTrebleIntensity(0f);
		SetBassIntensity(0f);
	}

	void OnTriggerEnter(Collider collide){
		if(collide.tag == "Player" && !triggered){
			triggered = true;
			PlayAudio();
		}
	}

	void Update() {
		float t = Mathf.PingPong (Time.time, duration) / duration;
		float targetIntensity = Mathf.Lerp (minIntensity, maxIntensity, t);
		RealSetMidtoneIntensity(targetIntensity);
		
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

		SetMidtoneIntensity(0f);
		SetTrebleIntensity(0f);
		SetBassIntensity(8f);
	}

	void SetMidtoneIntensity(float intensity) {
		if (intensity == 0) {
			minIntensity = maxIntensity = intensity;
			return;
		}

		minIntensity = intensity * .5f;
		maxIntensity = intensity * 2f;
    }

	void RealSetMidtoneIntensity(float intensity) {
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Midtones")) {
			obj.GetComponent<Light>().intensity = intensity;
		}
	}

	void SetTrebleIntensity(float intensity) {
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Emissive_Guardian")) {
			obj.GetComponent<Light>().intensity = intensity;
		}
	}

	void SetBassIntensity(float intensity) {
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Bass")) {
			obj.GetComponent<Light>().intensity = intensity;
		}
	}

	void PlayAudio2() {
		audio.clip = clip2;
		audio.Play();

		SetMidtoneIntensity(8f);
		SetTrebleIntensity(0f);
		SetBassIntensity(0f);
	}

	void PlayAudio3() {
		audio.clip = clip3;
		audio.Play();

		SetMidtoneIntensity(0f);
		SetTrebleIntensity(4f);
		SetBassIntensity(0f);
	}

	void ReturnJeers() {
		jeersTargetVol = jeersOriginalVol;
		canUpdate = true;

		SetMidtoneIntensity(1f);
		SetTrebleIntensity(1f);
		SetBassIntensity(2f);
	}
}
