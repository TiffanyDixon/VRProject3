using UnityEngine;
using System.Collections;

public class RotatingLights1 : MonoBehaviour {
	public float maxRot = 0;
	
	// Update is called once per frame
	void Update () {
			transform.Rotate(Vector3.up * 10 * Time.deltaTime);
		}
	}

