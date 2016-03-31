using UnityEngine;
using System.Collections;

public class IncreaseVolumeOnEnter : MonoBehaviour {

	public float finalVolume = 1f;
	private bool entered = false;
	private float startVolume;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource>();
		startVolume = sound.volume;
	}
	
	// Update is called once per frame
	void Update () {
		float targetVolume = entered ? finalVolume : startVolume;
		sound.volume = Mathf.Lerp(sound.volume, targetVolume, Time.deltaTime);
	}

	void OnTriggerEnter(Collider collider) {
		entered = entered || collider.tag == "Player";
	}
}
