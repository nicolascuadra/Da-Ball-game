using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class frezze : MonoBehaviour {


	private GameMaster gm;
	private GameMastertutorial gmt;
	public Transform camara;
	public VirtualJoystick joystickcam,joystickbola;

	public GameObject joyDer;
	public GameObject joyIzq;

	public GameObject bola;

	float oshorizontal;
	float osVertical; 
	float camini,y;
	float pantx;

	private AudioSource audso;

	float Joyhorizontal;
	float JoyVertical; 

	Rigidbody cuerpo;
	public float vel;
	Vector3 vx;
	private Vector3 reset;
	Vector3 resetcam;
	public int control = 1;

	private int temp;
	// Use this for initialization
	void Start () {

		audso = camara.GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("audio") == 0) {
			audso.mute = !audso.mute;

		}


		temp = SceneManager.GetActiveScene ().buildIndex;
		if (temp != 1) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();

		} else {
			gmt = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMastertutorial>();
		}

		vx = new Vector3 ();
		pantx = Screen.width / 2;
		reset = transform.position;
		resetcam = camara.rotation.eulerAngles;
		cuerpo = bola.GetComponent<Rigidbody>();
	   
	}

	// Update is called once per frame
	void Update () {
		
		if (transform.position.y < -10) {
			if (temp!=1) {
				gm.GameOver ();
			} else {
				gmt.GameOver ();
			}
		}
		RotarCam2 (Input.GetAxis ("rightjoyx") * 200 * Time.deltaTime);
		Vector3 Abajo = transform.TransformDirection (Vector3.down);

		if (Physics.Raycast (transform.position, Abajo, 3)) {
			Joyhorizontal = Input.GetAxis ("Horizontal");
			JoyVertical = Input.GetAxis ("Vertical");
			cuerpo.AddForce (this.transform.forward * 40 * vel * Time.deltaTime * JoyVertical);
			cuerpo.AddForce (this.transform.right * 40 * vel * Time.deltaTime * Joyhorizontal);
		}

		switch (control)
		{
		case 4:


		
			RotarCam2 (Input.GetAxis ("rightjoy x") * 200 * Time.deltaTime);
			//Vector3 Abajo = transform.TransformDirection (Vector3.down);

			if (Physics.Raycast (transform.position, Abajo, 3)) {
				Joyhorizontal = Input.GetAxis ("Horizontal");
				JoyVertical = Input.GetAxis ("Vertical");
				cuerpo.AddForce (this.transform.forward * 80 * vel * Time.deltaTime * JoyVertical);
				cuerpo.AddForce (this.transform.right * 80 * vel * Time.deltaTime * Joyhorizontal);
			}
			break;
		case 3:


			RotarCam2 (joystickcam.Horizontal()*170*Time.deltaTime);

			if (Input.touchCount > 0) {
				if (Input.GetTouch (0).position.x < pantx) {			
					movimiento_bola1 (0);
				}
				if (Input.touchCount > 1) {
					if (Input.GetTouch (1).position.x > pantx) {			
						movimiento_bola1 (1);
					}
				}
			}

			break;
		case 2:
			
			if (Input.touchCount > 0){						
					movimiento_bola1 (0);
					if (Input.GetTouch (0).phase == TouchPhase.Began) {
					camini = Input.GetTouch (0).position.x;
					}
					if (Input.GetTouch (0).position.x - camini > 40f || Input.GetTouch (0).position.x - camini < -40f) {
						RotarCam2 ((Input.GetTouch (0).position.x - camini) / 150f);
					}
			}

			break;
		case 1:
			
			RotarCam2 (joystickcam.Horizontal()*170*Time.deltaTime);
		//	RotarCamup (joystickcam.Vertical()*170*Time.deltaTime);
			movimiento_bola2 ();


			break;
		default:
			print ("Incorrect control level.");
			break;
		}

		this.transform.position = bola.transform.position;
	}





	void movimiento_bola1 (int touch){

		Vector3 Abajo = transform.TransformDirection (Vector3.down);

		if (Physics.Raycast (transform.position, Abajo, 3)) {


			if (Input.GetTouch (touch).phase == TouchPhase.Began) {
				oshorizontal = Input.acceleration.x;
				osVertical = Input.acceleration.y; 
				//	Debug.Log ("x = " + oshorizontal + " y = " + osVertical); 
			}

			float xx = oshorizontal - Input.acceleration.x + Joyhorizontal;
			float zz = osVertical - Input.acceleration.y + JoyVertical;


			cuerpo.AddForce (this.transform.forward * vel * zz * -1);
			cuerpo.AddForce (this.transform.right * vel * xx * -1);

		}
	}


	void movimiento_bola2 (){
		Vector3 Abajo = transform.TransformDirection (Vector3.down);

		if (Physics.Raycast (transform.position, Abajo, 3)) {
			Joyhorizontal = joystickbola.Horizontal ();
			JoyVertical = joystickbola.Vertical ();
			/*
			if ( Joyhorizontal > 0.85f ){
				Joyhorizontal = 0.85f;
			}
			if (Joyhorizontal < -0.85f){
				Joyhorizontal = -0.7f;
			}
			if ( JoyVertical > 0.85f ){
				JoyVertical = 0.7f;
			}
			if (JoyVertical < -0.85f){
				JoyVertical = -0.7f;
			}*/
			Joyhorizontal = Mathf.Pow (Joyhorizontal,2)/2;
			JoyVertical = Mathf.Pow (JoyVertical,2)/2;


			if (joystickbola.Horizontal ()<0) {
				Joyhorizontal*=-1;
			}

			if (joystickbola.Vertical ()<0) {
				JoyVertical*=-1;
			}
				
			cuerpo.AddForce (this.transform.forward *80* vel *Time.deltaTime* JoyVertical);
			cuerpo.AddForce (this.transform.right *80* vel *Time.deltaTime* Joyhorizontal);


	    }

	}


	void movimiento_camara (int touch){
		if (Input.GetTouch (touch).phase == TouchPhase.Began) {

			camini = Input.GetTouch (touch).position.x;
		}
		if (Input.GetTouch (touch).position.x - camini > 30f || Input.GetTouch (touch).position.x - camini < -30f) {
			RotarCam2 ((Input.GetTouch (touch).position.x - camini) / 120f);
		}
	}





	public void RotarCam (/*float ang*/) {
		transform.Rotate(resetcam);
		//transform.localRotation = (Vector3.up * ang * 30f, Space.World);
	}

	public void RotarCam2 (float ang) {
		transform.Rotate (Vector3.up * ang , Space.World);
	}

	public void RotarCamup (float ang) {
		transform.Rotate (Vector3.right * ang , Space.World);
	}

	/*
	public void PlayerReset()
	{
	//	RotarCam ();
		bola.transform.position = reset;
		cuerpo.velocity = new Vector3 (0, 0, 0);
	}
*/
	public void PlayerReset(Vector3 weypoint)
	{
		//RotarCam ();
		bola.transform.position = weypoint;
		cuerpo.velocity = new Vector3 (0, 0, 0);
	}


	public void MoverBola()
	{
		oshorizontal = Input.acceleration.x;
		osVertical = Input.acceleration.y; 

		float xx = oshorizontal - Input.acceleration.x + Joyhorizontal;
		float zz = osVertical - Input.acceleration.y + JoyVertical;
		Debug.Log (vx);
		cuerpo.AddForce (this.transform.forward * vel * zz * -1);
		cuerpo.AddForce (this.transform.right * vel * xx * -1);
	}

	public void MoverCamara()
	{
		if (Input.touchCount > 0) {
			RotarCam2 ((Input.GetTouch (0).position.x - camini) / 120f);
		}
	}

	public void CambiarControl(int num)
	{
		control = num;
		if (num == 1) {
			joyDer.SetActive (true);
			joyIzq.SetActive (true);
		} else if (num == 2) {
			joyDer.SetActive (false);
			joyIzq.SetActive (false);			
		} else if (num == 3) {
			joyDer.SetActive (false);
			joyIzq.SetActive (true);			
		}

	}





}
