using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class Direccion : MonoBehaviour {
	public int id;
	private int whereToGo;
	private JsonData itemData;
	private string gameDataFileName = "mapa.json";
	public GameObject north;
	public GameObject south;
	public GameObject east;
	public GameObject west;
	public GameObject destino;
	
	private char coordenada = 'c';

	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad(north);
		DontDestroyOnLoad(south);
		DontDestroyOnLoad(east);
		DontDestroyOnLoad(west);
	}


	// Use this for initialization
	void Start () {
		north.SetActive(false);
		south.SetActive(false);
		east.SetActive(false);
		west.SetActive(false);
		destino.SetActive(false);
		
		whereToGo = GameObject.Find ("ObjetoFijo").GetComponent<ObjetoFijo> ().getOpcion ();
		Debug.Log("Where to go: " + whereToGo);
		
		if(id + 1 == whereToGo){
			destino.SetActive(true);
			Debug.Log("Has llegado");
		}
		else{		
			readWhereToGo ();
			selectArrow();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void readWhereToGo(){
		//string filePath = Application.dataPath + gameDataFileName;

		var filePath = Resources.Load ("mapa") as TextAsset;

		// Read the json from the file into a string
		string dataAsJson = filePath.text; 

		itemData = JsonMapper.ToObject (dataAsJson);

		JsonData data = itemData[id];

		for (int i = 0; i < data.Count; i++){
			for (int j = 0; j < data [i].Count; j++) {
				int aux = int.Parse (data[i][j].ToString());
				if (aux == whereToGo && i == 0)
					coordenada = 'N';
				else if (aux == whereToGo && i == 1)
					coordenada = 'S';
				else if (aux == whereToGo && i == 2)
					coordenada = 'E';
				else if(aux == whereToGo && i == 3)
					coordenada = 'O';
			}
		}
		Debug.Log("Tengo estas coordenadas: "+data.Count);
		Debug.Log("El id de la sala " + whereToGo + " esta en la direccion: " + coordenada);
	}
	
	private void selectArrow(){
		switch(coordenada){
			case 'N': {
				Debug.Log(north);
				north.SetActive(true);
			}break;
			case 'S': {
				Debug.Log(south);
				south.SetActive(true);
			}break;
			case 'E': {
				Debug.Log(east);
				east.SetActive(true);
			}break;
			case 'O': {
				Debug.Log(west);
				west.SetActive(true);
			}break;
			default:
			{
				Debug.Log ("No ha elegido ninguna opcion");
			}
			break;
		}
	}
}