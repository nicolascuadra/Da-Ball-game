using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minapref : MonoBehaviour {

	public float FuerzaSalto = 1000f;
	public float Radio = 10f;

	void OnTriggerStay(Collider col){
		if (col.GetComponent<Movement> () != null) {
			col.GetComponent<Movement> ().Explota (Radio, FuerzaSalto, transform.position);
		}
	}
}
