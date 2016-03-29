using UnityEngine;
using System.Collections;


public class LightChanges : MonoBehaviour {
	public float duration = 1.0F;
	public Color firstColor = Color.red;
	public Color secondColor = Color.blue;
	public float intensity;
	public Light lt;

	// Use this for initialization
	void Start () {
		lt = GetComponent<Light> ();
	}

	// Update is called once per frame
	void Update () {
		float t = Mathf.PingPong (Time.time, duration) / duration;
		lt.color = Color.Lerp (firstColor, secondColor, t);
		lt.intensity = intensity;

	}
}
