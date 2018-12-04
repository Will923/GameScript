using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {

	string URL = "http://localhost/game/index.php";
	public string [] userData;

	// Use this for initialization
	IEnumerator Start () {

		WWW users = new WWW(URL);
		yield return users;
		string usersDataString = users.text;
		userData = usersDataString.Split(';');
		print(userData);

	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
