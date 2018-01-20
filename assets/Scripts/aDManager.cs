using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using UnityEngine.Advertisements;


public class aDManager : MonoBehaviour {


	private string ID = "1486628";
	// Use this for initialization
	void Start () {

	//	Advertisement.Initialize (ID,true);
	



	}
	
	// Update is called once per frame
	void Update () {

	}

	public void showad(){
		int addd = PlayerPrefs.GetInt ("ads");
		bool most = (addd % 4) == 0;
		Debug.Log (""+Advertisement.IsReady());
	
		if (Advertisement.IsReady()&& most) {
			Advertisement.Show ();
		}
	

	}



}
