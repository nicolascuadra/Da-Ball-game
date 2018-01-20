using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerapref : MonoBehaviour {

	public float FuerzaSalto = 100f;
	GameObject bola;
	private Vector3 vecdir;
	// Use this for initialization
	void Start () {
		Quaternion q = transform.rotation;
		vecdir = q * Vector3.forward;
		vecdir.Normalize ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerStay(Collider col){



		if (col.GetComponent<Movement> () != null) {
			
			col.GetComponent<Movement> ().saltar (FuerzaSalto,vecdir);

		}
		

	}

}
