using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setcolorlevel : MonoBehaviour {


	private Color32 ColorNivel;
	public byte R,G,B,A;
	public Material mAterial;



	// Use this for initialization
	void Start () {

		ColorNivel.r = R;
		ColorNivel.g = G;
		ColorNivel.b = B;
		ColorNivel.a = A;

	
		mAterial.color = ColorNivel;


		
	}
	

}
