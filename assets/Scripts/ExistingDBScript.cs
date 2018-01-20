using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExistingDBScript  {

	public Text DebugText;
	public int oro, estnec, estre, best;

	// Use this for initialization
	void Start () {


		



	}
	
	public IEnumerable<Level> readbyid(int id){
		var ds = new DataService ("Niveles.db");
		IEnumerable<Level> lvl = ds.Getlevelbyid(id);
		foreach (var Level in lvl) {
			this.oro = Level.Oro;
			this.estnec = Level.Estnec;
			this.estre = Level.Estrellas;
			this.best = Level.Best;
		}
		return lvl;
	}

	public int calcularestrellas(){
		int ests = 0;
		var ds = new DataService ("Niveles.db");
		IEnumerable<Level> lvl = ds.GetLevels ();
		foreach (var Level in lvl) {

				ests += Level.Estrellas;

		}
		this.updatefast (ests);
		PlayerPrefs.SetInt ("estrellas",ests);
		return ests;
	
	}

	public void updateestrellas(int est){
		var ds = new DataService ("Niveles.db");
		IEnumerable<Level> lvl = ds.Getlevelbyid(1);
		foreach (var Level in lvl) {
			Level.Estnec = est;
			ds.updatelevel (Level);
		}
	}


	private void updatefast(int est){
		var ds = new DataService ("Niveles.db");
		IEnumerable<Level> lvl = ds.Getlevelbyid(1);
		foreach (var Level in lvl) {
			Level.Estnec = est;
			ds.updatelevel (Level);
		}
	}


	public void updatedb(int tiempo,int estrellas, int id){
		
		if(this.best == 0 || tiempo < this.best){
			this.best = tiempo;
		}
		if(estrellas > this.estre ){
			this.estre = estrellas;
		}

		var ds = new DataService ("Niveles.db");
		IEnumerable<Level> lvl = ds.Getlevelbyid(id);
		foreach (var Level in lvl) {
			Level.Best = this.best;
			Level.Estrellas = this.estre;
			ds.updatelevel (Level);
		}

	}

	public IEnumerable<Level> getlevels(){
		var ds = new DataService ("Niveles.db");
		return ds.GetLevels ();
	}

	public void warning(){
		var ds = new DataService ("Niveles.db");
		ds.CreateDB ();
		
	}
	public void resetall(){
		
		updatefast (0);
		PlayerPrefs.SetInt ("estrellas",0);
		var ds = new DataService ("Niveles.db");
		IEnumerable<Level> lvl = ds.GetLevels();
		foreach (var Level in lvl) {
			Level.Best = 0;
			Level.Estrellas = 0;
			ds.updatelevel (Level);
		}

	}






}
