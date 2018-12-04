using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour {

	[SerializeField]
	private GameObject buttonTemplate;
	[SerializeField]
	private GridLayoutGroup gridGroup;
	public Text btnText;

	// Use this for initialization
	void Start () {
		GenInventory();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenInventory(){
		
		gridGroup.constraintCount = 15;

		foreach ( string weapon in GlobalControl.Instance.userWeapon){

			GameObject newButton = Instantiate(buttonTemplate) as GameObject;
			
			btnText.text = weapon;

			newButton.SetActive(true);

			newButton.transform.SetParent(buttonTemplate.transform.parent, false);

		}

	}

}
