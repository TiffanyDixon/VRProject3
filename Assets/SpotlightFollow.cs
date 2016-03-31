using UnityEngine;
using System.Collections;

public class SpotlightFollow : MonoBehaviour {

	private GameObject[] spotlights;
	private bool hasEntered = false;

	// Use this for initialization
	void Start () {
		spotlights = GameObject.FindGameObjectsWithTag("Stagelight");
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasEntered) return;
		foreach (GameObject spotlight in spotlights) {
			spotlight.transform.LookAt(transform);
		}
	}

	void OnTriggerEnter(Collider collider) {
		hasEntered = hasEntered || collider.tag == "Spotlight Collider";
	}
}
