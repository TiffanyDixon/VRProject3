using UnityEngine;
using System.Collections;

public class IncreaseVolumeOnEnter : MonoBehaviour {

	public float finalVolume = 1f;
	private bool entered = false;
	private float startVolume;
	private AudioSource sound;
	private bool stopChanging = false;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource>();
		startVolume = sound.volume;
	}
	
	// Update is called once per frame
	void Update () {
		if (stopChanging) return;
		float targetVolume = entered ? finalVolume : startVolume;
		sound.volume = Mathf.Lerp(sound.volume, targetVolume, Time.deltaTime);
		if (entered && Mathf.Abs(targetVolume - sound.volume) < .03f) {
			stopChanging = true;
		}
	}

	void OnTriggerEnter(Collider collider) {
		entered = entered || collider.tag == "Player";
	}
}
