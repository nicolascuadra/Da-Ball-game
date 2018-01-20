using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarenx : MonoBehaviour {


	public GameObject obarot;
	public float vel = 1.5f;


	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update () {


		obarot.transform.Rotate (new Vector3(0f,0f,vel)*Time.deltaTime);

	}

}