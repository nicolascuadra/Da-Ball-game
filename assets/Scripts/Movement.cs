using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
	
	//velocidad del cuerpo
	[SerializeField]
	private float speed;

	//Rigidbody
	private Rigidbody rgbd;
	private GameMaster gm;
	private GameMastertutorial gmt;
	private int temp;
	// Use this for initialization
	void Start () {
		temp =SceneManager.GetActiveScene ().buildIndex;

		rgbd = GetComponent<Rigidbody> ();
		if (temp != 1) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();
		} else {
			gmt = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMastertutorial> ();
		}
	}

	public void MoveBall (Vector3 vector){
		rgbd.AddForce (vector * speed);
	}
		
	public void saltar(float intencidad, Vector3 dir){
		rgbd.velocity = Vector3.zero;
		rgbd.angularVelocity = Vector3.zero; 
		rgbd.AddForce (dir * intencidad);
	}

	public void Explota(float radio,float intencidad, Vector3 pos){
		rgbd.AddExplosionForce (intencidad, pos, radio);
	}

	void OnTriggerEnter(Collider col){




		if (col.gameObject.tag == "Finish") {

			if (temp != 1) {
				gm.endlevel ();
			} else {
				gmt.endlevel ();
			}

		}

	}
}
