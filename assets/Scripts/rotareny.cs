using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotareny : MonoBehaviour {

	public GameObject obarot;
	public float vel = 1.5f;


	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update () {


		obarot.transform.Rotate (new Vector3(0f,vel,0f)*Time.deltaTime);

	}

}