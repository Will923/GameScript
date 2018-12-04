using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * 20 * Time.deltaTime);
	}

	void OnCollisionEnter (Collision detect)
    {

        
			Destroy(this.gameObject, 3f);
        

    }

	void OnTriggerEnter (Collider detect)
	{
		if(detect.gameObject.name != "Nzinga")
        {
			Destroy(this.gameObject);
		}

	}

}
