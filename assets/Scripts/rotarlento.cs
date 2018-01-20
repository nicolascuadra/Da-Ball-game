using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarlento : MonoBehaviour {


	public GameObject obarot;
	public Material mAterial;
	private Color32 colour;
	public float vel = 1.5f;


	// Use this for initialization
	void Start () {
		
		

	}
	
	// Update is called once per frame
	void Update () {


		obarot.transform.Rotate (new Vector3(0f,0f,vel)*Time.deltaTime);
		
	}

	public void SetColor(Color32 colour)
	{

		mAterial.color = colour;
	}
}
