using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstateFlecha : MonoBehaviour {

	public Transform target;
	public GameObject arrowPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Instantiate(arrowPrefab, target.position, target.rotation);
		//	StartCoroutine( destruir() );
		}
	}
/* 
	IEnumerator destruir(){
		yield return new WaitForSeconds(5);
		Destroy(this.arrowPrefab.gameObject);
	}*/

}
