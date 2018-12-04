using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {

		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothPosition;
		transform.eulerAngles = new Vector3( transform.eulerAngles.x, target.transform.eulerAngles.y, transform.eulerAngles.z);
		transform.LookAt(target);

	}

}
