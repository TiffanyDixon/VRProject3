using UnityEngine;
using System.Collections;

public class MidtoneSpheres : MonoBehaviour {
	public float duration = 1.0F;
	public Light halo;
	public float intensity;

	// Use this for initialization
	void Start () {
		halo = GetComponent<Light> ();

	}
	
	// Update is called once per frame
	void Update (int intensity) {
		halo.intensity = intensity;
	
	}
}
