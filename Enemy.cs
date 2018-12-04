using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	bool fallow;
	GameObject player;
	public Animator animator;
	NavMeshAgent enemy;
	// Use this for initialization
	void Start () {
		fallow = true;
		player = GameObject.FindGameObjectWithTag("Nzinga");
		enemy = GetComponent<NavMeshAgent>();
		animator = this.gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if(fallow)
			enemy.destination = player.transform.position;
	}

	void OnCollisionEnter (Collision detect)
    {

        if(detect.gameObject.name == "flecha(Clone)" & fallow == true)
        {
			
			Debug.Log("Colisor 1024");
            animator.SetTrigger("die");
			fallow = false;
			Destroy(this.gameObject, 3f);

        }else if(detect.gameObject.name == "Nzinga" & fallow == true)
        {
			detect.gameObject.GetComponent<NzingaController>().hit(3f);
		} 

    }

	void OnTriggerEnter (Collider detect)
	{
		if(detect.gameObject.name == "flecha(Clone)" & fallow == true){
			
			animator.SetTrigger("die");
			fallow = false;
			Destroy(this.gameObject, 13f);
		
		}else if(detect.gameObject.name == "Nzinga" & fallow == true)
        {
			detect.gameObject.GetComponent<NzingaController>().hit(3f);
		} 

	}

}
