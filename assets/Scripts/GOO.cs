using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOO : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter (Collider col){


		//GameObject g = GameObject.Find("GameMaster");
		//g.GetComponent<GameMaster> ().GameOver ();
		FindObjectOfType<GameMaster>().GameOver();


	}
}
