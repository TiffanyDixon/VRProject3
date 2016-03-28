using UnityEngine;
using System.Collections;

public class PulseSize : MonoBehaviour {

	public float damping = 0.08f;
	Vector3 originalSize;

	// Use this for initialization
	void Start () {
		originalSize = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.Slerp(
			transform.localScale,
			originalSize + damping * Vector3.one * Mathf.Cos(Time.time),
			Time.deltaTime
		);
	}
}
