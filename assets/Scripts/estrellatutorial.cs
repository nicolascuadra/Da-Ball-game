using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estrellatutorial : MonoBehaviour {


	private GameMastertutorial gmt;
	// Use this for initialization
	void Start () {
		gmt = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMastertutorial> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.GetComponent<Movement> () != null) {
			
			gmt.tutorial();
			}

		}
	}

