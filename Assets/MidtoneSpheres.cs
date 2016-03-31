using UnityEngine;
using System.Collections;

public class MidtoneSpheres : MonoBehaviour {
	public float duration = 1.0F;
	public Light halo;
	public float intensity;
	public float minIntensity = 0.25f;
	public float maxIntensity = 0.75f;

	public int oscChannel = 2;

	// Use this for initialization
	void Start () {
		halo = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		float t = Mathf.PingPong (Time.time, duration) / duration;
		halo.intensity = Mathf.Lerp (minIntensity, maxIntensity, t);	*/

		OSCReceiver oscr = FindObjectOfType<OSCReceiver>();
		//OSCReceiver oscr = GetComponent<OSCReceiver> ();
		intensity = oscr.getMessage (oscChannel);
		halo.intensity = intensity;
	}
}
