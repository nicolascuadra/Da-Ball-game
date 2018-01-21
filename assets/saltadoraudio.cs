using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltadoraudio : MonoBehaviour {


	private AudioSource audso;
	// Use this for initialization
	void Start () {
		audso = GetComponent<AudioSource> ();
	}



	void OnTriggerEnter(Collider col){


		if (col.GetComponent<Movement> () != null) {

			audso.Play ();

		}
	}
}
