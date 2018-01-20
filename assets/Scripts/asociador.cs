using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asociador : MonoBehaviour {

	public Transform objeto;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider col){

		col.transform.parent = objeto.transform; 
	}

	void OnTriggerExit(Collider col){

		col.transform.parent = null;
	}
}
