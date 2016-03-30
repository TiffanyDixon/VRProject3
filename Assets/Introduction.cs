using UnityEngine;
using System.Collections;

public class Introduction : MonoBehaviour {

	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;


	void onTriggerEnter(Collider collide){
		AudioSource audio = GetComponent<AudioSource>();
		if(collide.tag == "Player"){
			audio.clip = clip1;
			audio.Play();
			wait ();
			audio.clip = clip2;
			audio.Play();
			wait ();
			audio.clip = clip3;
			audio.Play();
		}
	}

	IEnumerator wait(){
		yield return new WaitForSeconds (5F);
}
}
