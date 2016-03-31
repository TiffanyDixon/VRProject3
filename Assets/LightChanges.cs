using UnityEngine;
using System.Collections;


public class LightChanges : MonoBehaviour {
	public float duration = 1.0F;
	public Color firstColor = Color.red;
	public Color secondColor = Color.blue;
	public float intensity;
	public Light lt;

	public int oscChannel;

	private 

	// Use this for initialization
	void Start () {
		lt = GetComponent<Light> ();
	}

	// Update is called once per frame
	void Update () {
		float t = Mathf.PingPong (Time.time, duration) / duration;
		lt.color = Color.Lerp (firstColor, secondColor, t);
		//lt.intensity = intensity;
		OSCReceiver oscr = FindObjectOfType<OSCReceiver>();
		//OSCReceiver oscr = GetComponent<OSCReceiver> ();
		intensity = oscr.getMessage (oscChannel);
		lt.intensity = intensity * 8.0f;
		//messages[oscChannel];
	}
}