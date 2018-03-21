using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoFijo : MonoBehaviour {

	public int opcion;

	// Use this for initialization
	void Awake() {
		
		DontDestroyOnLoad(transform);	//Con ésto, evitamos que se destruya el GameObject al pasar de escena.
	}

	public void setOpcion(int o){

		opcion = o;
	}

	public int getOpcion(){
		
		return opcion;		//Para recoger opcion utilizariamos lo siguiente: 	GameObject.Find("ObjetoFijo").GetComponent<ObjetoFijo>().getOpcion(opcion);

	}
}
