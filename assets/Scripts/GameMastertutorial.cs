using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMastertutorial : MonoBehaviour {

	public int NumeroNivel = 0;

	public frezze Player;
	public Image Estrella;

	public GameObject[] Estrellas;
	public Text ContEstrella,ContEstrella2;
	public Text TiempoText,TiempoText2;
	public GameObject PanelPausa;
	public GameObject PanelGO;
	public GameObject PanelControles;
	public GameObject BotonControl1;
	public GameObject BotonControl2;
	public GameObject BotonControl3;
	public GameObject BotonContinuar;
	public GameObject BotonPause;
	public GameObject BotonEstrellas;
	public GameObject BotonTiempo;
	public GameObject panelfinal;
	public GameObject Pltuto01,Pltuto02,Pltuto03,Pltuto04,Pltuto05,Pltuto06,Pltuto07;

	public GameObject saltitut;
	public GameObject joy1,joy2,controltactil;

	public Image Est1;
	public Image Est2;
	public Image Est3;



	private int temp = 0;


	private Color32 ColorNivel;
	public rotarlento rt;
	public byte R,G,B,A;
	//public Text EstrellasFinal;
	//public Text TiempoFinal;
	public Vector3 PosWaypoint;

	private aDManager adisita;

	private int CantEstrellas;
	private int time,seg=0,min=0;
	private bool pause = true;
	// Use this for initialization
	void Start () {
		controltactil.SetActive (false);
		deactivecontrols();
		saltitut.SetActive (false);

		StartCoroutine (esperar ());

		adisita = new aDManager ();
		PlayerPrefs.SetInt ("ads", (PlayerPrefs.GetInt("ads")+1));

		int val = PlayerPrefs.GetInt ("option");
		if (val == 0) {
			val = 1;
		}
		Player.CambiarControl (val);


		
		ContEstrella.text = CantEstrellas.ToString();
		ContEstrella2.text = CantEstrellas.ToString();
		InvokeRepeating ("Tiempo", 0, 1);
		Time.timeScale = 1;

		ColorNivel.r = R;
		ColorNivel.g = G;
		ColorNivel.b = B;
		ColorNivel.a = A;
		rt.SetColor (ColorNivel);



		tutorial ();
	}

	IEnumerator esperar() {

		yield return new WaitForSeconds(1f);
		Time.timeScale = 0;
		pause = true;
		}

	private void deactivecontrols(){
		int val = PlayerPrefs.GetInt ("option");

		switch (val){
		case 1:{
				joy1.SetActive (false);
				joy2.SetActive (false);
				break;
			}

		case 2:{
				joy2.SetActive (false);
				break;
			}
		}
	
	}

	private void reactivecontrols(){
		int val = PlayerPrefs.GetInt ("option");
		controltactil.SetActive (true);

		switch (val){
		case 1:{
				joy1.SetActive (true);
				joy2.SetActive (true);
				break;
			}

		case 3:{
				joy2.SetActive (true);
				break;
			}
		}

	}


public void tutorial(){
		BotonPause.SetActive (false);
		
		switch (temp) {

		case 0:
			{				
			Pltuto01.SetActive (true);
			temp = 1;
				break;
			}
		case 1:
			{
				Pltuto02.SetActive (true);
				Pltuto01.SetActive (false);
				temp = 2;
				break;
			}
		case 2:
			{
				Pltuto03.SetActive (true);
				Pltuto02.SetActive (false);
				temp = 3;
				break;
			}
		case 3:
			{
				Pltuto04.SetActive (true);
				Pltuto03.SetActive (false);
				temp = 4;
				break;
			}
		case 4:
			{
				Pltuto05.SetActive (true);
				Pltuto04.SetActive (false);


				temp = 5;
				break;
			}
		case 5:
			{
				BotonPause.SetActive (true);
				//Pltuto05.SetActive (true);
				Pltuto05.SetActive (false);
				reactivecontrols ();
				Time.timeScale = 1;
				pause = false;
				temp = 6;
				break;
			}
		case 6:
			{
				
				
				//Pltuto01.SetActive (true);
				saltitut.SetActive (true);
				Time.timeScale = 0;
				pause = true;
				Pltuto06.SetActive (true);
				controltactil.SetActive (false);
				temp = 7;
				break;
			}
		case 7:
			{
				//Pltuto05.SetActive (true);
				//Pltuto01.SetActive (true);
				Pltuto06.SetActive (false);
				reactivecontrols ();
				BotonPause.SetActive (true);
				Time.timeScale = 1;
				pause = false;
				temp = 8;
				break;
			}

		}
	}

	public void SumarEstrella(int Cant, Vector3 pos)
	{
		CantEstrellas += Cant;
		ContEstrella.text = CantEstrellas.ToString();
		ContEstrella2.text = CantEstrellas.ToString();
		PosWaypoint = pos;
	}

	public void ResetLevel()
	{
		Fading.Instance.StartFade (/*"escena01"*/SceneManager.GetActiveScene ().buildIndex, false);
		Time.timeScale = 1;
		/*panelfinal.SetActive (false);
		PanelPausa.SetActive (false);
		BotonContinuar.SetActive (true);
		BotonPause.SetActive (true);
		BotonEstrellas.SetActive (true);
		BotonTiempo.SetActive (true);
		pause = false;
		for(int i = 0; i<3; i++)
		{
			Estrellas[i].SetActive(true);
		}
		CantEstrellas = 0;
		time = 0;
		TiempoText.text = time.ToString ();
		ContEstrella.text = CantEstrellas.ToString();
		Player.PlayerReset ();*/
	}
		
	void Tiempo()
	{
		time += 1 ;
		seg += 1 ;
		if (seg >= 60) {
			min = min + 1;
			seg = 0; 
		}


		TiempoText.text = min.ToString()+":"+seg.ToString ();
		TiempoText2.text = min.ToString()+":"+seg.ToString ();
	}

	public void Pause()
	{
		if (!pause) {
			PanelPausa.SetActive (true);
	//	--------------------------//	BotonPause.SetActive (false);
			//BotonEstrellas.SetActive (false);
			//BotonTiempo.SetActive (false);
			//TiempoFinal.text = "Tiempo: " + time.ToString ();
			//EstrellasFinal.text = "Estrellas: " + CantEstrellas.ToString ();
			Time.timeScale = 0;
			pause = true;
		} else {
			PanelPausa.SetActive (false);
			BotonPause.SetActive (true);
			//BotonEstrellas.SetActive (true);
			//BotonTiempo.SetActive (true);
			Time.timeScale = 1;
			pause = false;
		}
	}

	public void ContinuarWP()
	{
		Time.timeScale = 1;
		PanelGO.SetActive (false);
		BotonPause.SetActive (true);
	}

	public void GameOver()
	{
		if (CantEstrellas > 0) {

			Player.PlayerReset (PosWaypoint);
			Time.timeScale = 0;
			PanelGO.SetActive (true);
			BotonPause.SetActive (false);

		} else {
			Fading.Instance.StartFade (/*"escena01"*/SceneManager.GetActiveScene ().buildIndex, false);
		}
	/*	Player.PlayerReset ();
		BotonContinuar.SetActive (true);
		BotonEstrellas.SetActive (true);
		BotonTiempo.SetActive (true);
		BotonPause.SetActive (true);
		//TiempoFinal.text = time.ToString ();
		//EstrellasFinal.text = CantEstrellas.ToString ();
		for(int i = 0; i<3; i++)
		{
			Estrellas[i].SetActive(true);
		}
		CantEstrellas = 0;
		time = 0;
		TiempoText.text = time.ToString ();
		ContEstrella.text = CantEstrellas.ToString();

		Pause ();*/
	}

	public void Salir()
	{
		adisita.showad ();
		Time.timeScale = 1;
		pause = false;
		PanelPausa.SetActive (false);
		panelfinal.SetActive (false);
		Fading.Instance.StartFade (0, false);
	}

	public void Controles()
	{
		BotonPause.SetActive (false);
		int val = PlayerPrefs.GetInt ("option");
		if (val == 0) {
			val = 1;
		}
		switch (val) {
		case 1:
			{
				BotonControl1.GetComponent<Image> ().color = ColorNivel;
				BotonControl2.GetComponent<Image> ().color = Color.grey;
				BotonControl3.GetComponent<Image> ().color = Color.grey;
				break;
			}
		case 2:
			{
				BotonControl1.GetComponent<Image>().color = Color.grey;
				BotonControl2.GetComponent<Image>().color = Color.grey;
				BotonControl3.GetComponent<Image>().color = ColorNivel;
				break;
			}
		case 3:
			{
				BotonControl1.GetComponent<Image>().color = Color.grey;
				BotonControl2.GetComponent<Image>().color = ColorNivel;
				BotonControl3.GetComponent<Image>().color = Color.grey;
				break;
			}


		}
			

		PanelPausa.SetActive (false);
		PanelControles.SetActive (true);
	}

	public void Control1()
	{
		BotonControl1.GetComponent<Image>().color = ColorNivel;
		BotonControl2.GetComponent<Image>().color = Color.grey;
		BotonControl3.GetComponent<Image>().color = Color.grey;

		Player.CambiarControl (1);
		PlayerPrefs.SetInt ("option",1);
	}
	public void Control2()
	{
		BotonControl1.GetComponent<Image>().color = Color.grey;
		BotonControl2.GetComponent<Image>().color = Color.grey;
		BotonControl3.GetComponent<Image>().color = ColorNivel;

		Player.CambiarControl (2);
		PlayerPrefs.SetInt ("option",2);
	}
	public void Control3()
	{

		BotonControl1.GetComponent<Image>().color = Color.grey;
		BotonControl2.GetComponent<Image>().color = ColorNivel;
		BotonControl3.GetComponent<Image>().color = Color.grey;

		Player.CambiarControl (3);
		PlayerPrefs.SetInt ("option",3);
	}

	public void Atras()
	{
		if (!BotonPause.activeSelf) {
			BotonPause.SetActive (true);
		}
		PanelPausa.SetActive (true);
		PanelControles.SetActive (false);

	}



	public void siguiente(){
		adisita.showad ();
		Time.timeScale = 1;
		pause = false;
		Fading.Instance.StartFade (/*"escena01"*/SceneManager.GetActiveScene().buildIndex+1,false);

	}

	private void sumarest(){

		int temp;
		ExistingDBScript db = new ExistingDBScript ();
		IEnumerable<Level> lvl = db.readbyid(SceneManager.GetActiveScene ().buildIndex);
		foreach (var Level in lvl) {
			if (Level.Estrellas < CantEstrellas) {
				temp = PlayerPrefs.GetInt ("estrellas");
				temp += (CantEstrellas - Level.Estrellas);
				PlayerPrefs.SetInt ("estrellas",temp);
				db.updateestrellas (temp);
			}
		}

		db.readbyid (SceneManager.GetActiveScene ().buildIndex);
		db.updatedb (time,CantEstrellas,SceneManager.GetActiveScene ().buildIndex);

	}

	public void endlevel(){
		sumarest ();






		Time.timeScale = 0;
		pause = true;
		panelfinal.SetActive (true);

		if(CantEstrellas == 1)
		{
			Est1.color = ColorNivel;
		} else if(CantEstrellas == 2)
		{
			Est1.color = ColorNivel;
			Est2.color = ColorNivel;
		} else if(CantEstrellas == 3)
		{
			Est1.color = ColorNivel;
			Est2.color = ColorNivel;
			Est3.color = ColorNivel;
		}


	


	}


}
