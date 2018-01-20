using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumppref : MonoBehaviour {

	public float FuerzaSalto = 1000f;
	GameObject bola;
	private Vector3 vecdir;
	// Use this for initialization
	void Start () {
		Quaternion q = transform.rotation;
		vecdir = q * Vector3.up;
		vecdir.Normalize ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider col){



		if (col.GetComponent<Movement> () != null) {
			
			col.GetComponent<Movement> ().saltar (FuerzaSalto,vecdir);

		}
		

	}

}
