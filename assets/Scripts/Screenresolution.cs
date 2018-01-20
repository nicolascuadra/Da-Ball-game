using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenresolution : MonoBehaviour {

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void setresolution(){
		int x = Screen.height;
		int y = Screen.width;

		if (x > 1400) {
			Screen.SetResolution (1920, 1080, true);

			PlayerPrefs.SetInt ("graficos", 0);
		} else {
			if (x > 1000) {
				Screen.SetResolution (1280, 720, true);

				PlayerPrefs.SetInt ("graficos", 1);
			} else {	
				if (x > 400)
					//Screen.SetResolution (x, y, true);
				    
				    PlayerPrefs.SetInt ("graficos", 2);
			}


		}
	}



}
