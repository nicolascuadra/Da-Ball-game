using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



using UnityEngine.Advertisements;



public class Menu : MonoBehaviour {
	
	public GameObject PanelPrincipal;
	public GameObject PanelMundo;
	public GameObject PanelSelectMundo;
	public GameObject Panelmas,Panelsalir;
	public GameObject Panelsettings,btnsett;
	public GameObject Atras;
	public Text b1, b2,borrar01,borrar02,graph1,graph2;
	public Image est1, est2, est3,souact,souinactv;
	public AudioClip soundatras;
	public AudioClip soundadela;
	private int paselvl= 1,opt;
	public Button ComenzarBoton;
	public Button SandboxBoton;
	public Button MasBoton;
	public Button AtrasBoton;
	public Button soundbtn;
	private int abrirlvl;
	private int borrar=0;
	private AudioSource audso;
	private AudioSource audiomenu;
	public GameObject camaudio;

	private Color32 ColorNivel;
	public rotarlento rt;
	public byte R,G,B,A;

	public  GameObject[] btnmundosinac; 
	public  GameObject[] btnmundosact; 
	public  Text[] txtestrellas; 
	public  Text[] txtestrellas2; 

	private aDManager adisita;
	// Use this for initialization
	private string ID = "1486628";


	void Start () {

		Advertisement.Initialize (ID,true);
		
		if ((PlayerPrefs.GetInt ("bandera")) != 3) {
			Debug.Log("nunca deberia verse esto");
			Screenresolution s = new Screenresolution ();
			s.setresolution ();
			QualitySettings.SetQualityLevel (PlayerPrefs.GetInt ("graficos"));
			PlayerPrefs.SetInt ("bandera", 3);
			PlayerPrefs.SetInt ("audio", 1);

		}


		audiomenu = camaudio.GetComponent<AudioSource>();
		if (PlayerPrefs.GetInt ("audio") == 0) {
//			audso.mute = !audso.mute;
			audiomenu.mute = !audiomenu.mute;
		
		}



		adisita = new aDManager ();
		PlayerPrefs.SetInt ("ads", (PlayerPrefs.GetInt("ads")+1));

		audso = GetComponent<AudioSource> ();
		PanelPrincipal.SetActive (true);
		PanelMundo.SetActive (false);
		Atras.SetActive (false);
		SetBotones ();
		ExistingDBScript db = new ExistingDBScript ();
		db.calcularestrellas ();




		ColorNivel.r = R;
		ColorNivel.g = G;
		ColorNivel.b = B;
		ColorNivel.a = A;
		rt.SetColor (ColorNivel);
	}

	public void exit(){
		Application.Quit ();
	}


	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			
			if (PanelPrincipal.activeSelf) {
				PanelPrincipal.SetActive (false);
				btnsett.SetActive (false);
				Panelsalir.SetActive (true);

			} else {
				btnsett.SetActive (true);
				
				Panelsalir.SetActive (false);
				if (Panelsettings.activeSelf) {
					Panelsettings.SetActive (false);
					PanelPrincipal.SetActive (true);

				} else {
					
					this.AtrasMenu ();
				}
			}
		}

	}

	void SetBotones()
	{
		ComenzarBoton.onClick.AddListener (delegate {
			Comenzar ();
		});
		AtrasBoton.onClick.AddListener (delegate {
			AtrasMenu ();
		});
	}

	void Comenzar()
	{
		


		prepBotones ();
		audso.PlayOneShot (soundadela);
		PanelPrincipal.SetActive (false);
		PanelMundo.SetActive (true);
		Atras.SetActive (true);
		btnsett.SetActive (false);
	}





	void AtrasMenu()
	{
		audso.PlayOneShot (soundatras);
		switch (paselvl) {
		case 0:
			{
				PanelSelectMundo.SetActive (false);
				PanelMundo.SetActive (true);

				paselvl = 1;
				break;	
			} 
		case 1:
			{

				PanelPrincipal.SetActive (true);
				btnsett.SetActive (true);
				PanelMundo.SetActive (false);
				Atras.SetActive (false);
				break;
			}
		case 2:
			{

				Panelmas.SetActive (false);
				btnsett.SetActive (true);
				PanelPrincipal.SetActive (true);
				Atras.SetActive (false);
				paselvl = 1;
				break;
			}
		}

	}

	public void audioaction(){
		int temp = PlayerPrefs.GetInt ("audio");

		if (temp == 1) {
			temp = 0;
		}else{
			temp = 1;}

		audso.mute = !audso.mute;
		audiomenu.mute = !audiomenu.mute;

		if (temp == 1) {
			
			souinactv.gameObject.SetActive (false);
			souact.gameObject.SetActive (true);
		} else {
			

			souact.gameObject.SetActive (false);
			souinactv.gameObject.SetActive (true); 
		}


		PlayerPrefs.SetInt ("audio", temp);

	

	}

	public void settingtransaction(){

		if (PanelPrincipal.activeSelf) {
			int fr = PlayerPrefs.GetInt ("graficos");
			switch (fr) {

			case 0:
				{
					graph1.text = "HIGH";
					graph2.text = "HIGH";
					break;
				}
			case 1:
				{
					graph1.text = "MEDIUM";
					graph2.text = "MEDIUM";
					break;
				}
			case 2:
				{
					graph1.text = "LOW";
					graph2.text = "LOW";
					break;
				}
			}

			if (PlayerPrefs.GetInt ("audio") == 1) {
				souact.gameObject.SetActive (true);
			} else {
				souinactv.gameObject.SetActive (true); 
			}

			
			PanelPrincipal.SetActive (false);
			Panelsettings.SetActive (true);
		} else {
			PanelPrincipal.SetActive (true);
			Panelsettings.SetActive (false);
		}

		}


	public void setgraph(){
		
		opt = PlayerPrefs.GetInt ("graficos");
		opt++;
		if (opt == 3)
			opt = 0;
		switch(opt){

		case 0:
			{
				graph1.text = "HIGH";
				graph2.text = "HIGH";

				QualitySettings.SetQualityLevel (0);
				PlayerPrefs.SetInt ("graficos", 0);
				break;
			}
		case 1:
			{
				graph1.text = "MEDIUM";
				graph2.text = "MEDIUM";
			
				QualitySettings.SetQualityLevel (1);
				PlayerPrefs.SetInt ("graficos", 1);
				break;
			}
		case 2:
			{
				graph1.text = "LOW";
				graph2.text = "LOW";

				QualitySettings.SetQualityLevel (2);
				PlayerPrefs.SetInt ("graficos", 2);
				break;
			}


	
	}
	}




	public void SelecMundo(int num)
	{
		audso.PlayOneShot (soundadela);
		paselvl = 0;
		PanelMundo.SetActive (false);
		this.abrirlvl = num;
		int best = 0;
		int est = 0;
		ExistingDBScript db = new ExistingDBScript ();
		IEnumerable<Level> lvl = db.readbyid (abrirlvl);
		foreach (var Level in lvl) {
			best = Level.Best;
			est = Level.Estrellas;

		}
		int min = best / 60;
		int seg = best % 60;
		string temp1 = min + " : " + seg; 
		b1.text = temp1; 
		b2.text = temp1;

		switch (est) {
		case 0:
			{
				est1.color = Color.grey;
				est2.color = Color.grey;
				est3.color = Color.grey;
				break;
			}
		case 1:
			{
				est1.color = Color.white;
				est2.color = Color.grey;
				est3.color = Color.grey;
				break;
			}
		case 2:
			{
				est1.color = Color.white;
				est2.color = Color.white;
				est3.color = Color.grey;
				break;
			}
		case 3:
			{
				est1.color = Color.white;
				est2.color = Color.white;
				est3.color = Color.white;
				break;
			}



		}




		PanelSelectMundo.SetActive (true);
	
	}


	public void openlevel(){
		adisita.showad ();
		Fading.Instance.StartFade (abrirlvl,false);
	}

	private void prepBotones(){


		int estotal = PlayerPrefs.GetInt("estrellas");
		ExistingDBScript db = new ExistingDBScript ();


		for (int i = 1; i < 18; i++) {
			
			IEnumerable<Level> lvl = db.readbyid (i+2);
			txtestrellas[i-1].text ="-"+(db.estnec - estotal);
			txtestrellas2[i-1].text = "-"+(db.estnec - estotal);

			if ((db.estnec - estotal) <= 0) {
				btnmundosinac [i - 1].SetActive (false);
				btnmundosact [i - 1].SetActive (true);			
			} else {
				btnmundosinac [i - 1].SetActive (true);
				btnmundosact [i - 1].SetActive (false);	
			
			}

			

		}





	
	}


	public void creditos(){
		
		btnsett.SetActive (false);
		audso.PlayOneShot (soundadela);
		borrar01.text="Delete Player";
		borrar02.text="Delete Player";			
		PanelPrincipal.SetActive (false);
		Panelmas.SetActive(true);
		Atras.SetActive (true);
		paselvl = 2;

	}
	public void borrartodo(){


		switch (borrar){
		case 0:
			{
				borrar01.text="R U Sure?";
				borrar02.text="R U Sure?";
				borrar = 1;
				break;
			}

		case 1:
			{
				borrar01.text="YES!";
				borrar02.text="YES!";
				borrar = 2;
				break;
			}

		case 2:
			{
				ExistingDBScript db = new ExistingDBScript ();
				db.resetall ();
				borrar = 3;
				break;
			}

		case 3:
			{
				borrar01.text="Deleted";
				borrar02.text="Deleted";
				borrar = 4;
				break;
			}

		case 4:
			{
				borrar01.text="Delete player";
				borrar02.text="Delete player";
				borrar = 0;
				break;
			}


	

		}
	}



	public void youtube01 (){

		Application.OpenURL("https://www.youtube.com/user/JamieNordMusic/videos/");
	}

	public void ionplaystore (){


		Application.OpenURL ("https://play.google.com/store/apps/developer?id=Iongeger%20Apps&hl=es");
	
	
	}



	//------------modificar int para sandbox cada vez que se agregue nivel
	public void sandbox(){
		Fading.Instance.StartFade (6,false);

	}
}
