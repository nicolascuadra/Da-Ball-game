using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Estrella : MonoBehaviour {

	private GameMaster gm;
	private GameMastertutorial gmt;
	private int temp;



	void Start () {
		temp =SceneManager.GetActiveScene ().buildIndex;
		
		if (temp != 1) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();
		} else {
			gmt = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMastertutorial> ();
		}



	}


	void Update () {
		transform.Rotate (new Vector3 (0, Time.deltaTime * 50, 0));
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.GetComponent<Movement> () != null) {
			gameObject.SetActive (false);
			if (temp != 1) {
				gm.SumarEstrella (1,transform.position);
			} else {
				gmt.SumarEstrella (1,transform.position);
			}

		}
	}
}
