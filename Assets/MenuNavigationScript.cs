using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class MenuNavigationScript : MonoBehaviour {

	public RectTransform mainMenuPanel;    //reference for MainMenupanel
	public Animator mainMenuAnimator;   //Animator reference
	public TextAsset position;

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){   //check if escape key is pressed
			if((int)mainMenuPanel.localScale.x==0){ //check if scale of MainMenu Panel is 0
				mainMenuAnimator.Play("MainMenuFadeIn"); //play fade in animation
			}
		}
	}

	public void cambioEscena(string nombreEscena){

		//StreamWriter writer = new StreamWriter ("Assets/writePosition.txt", true);
		//writer.WriteLine (opcion);
		//writer.Close ();
		//Debug.Log (opcion);

		int opcion_1 = recuperarOpcion ();

		GameObject.Find("ObjetoFijo").GetComponent<ObjetoFijo>().setOpcion(opcion_1);
		SceneManager.LoadScene(nombreEscena);
		//int opcion_2 = GameObject.Find ("ObjetoFijo").GetComponent<ObjetoFijo> ().getOpcion();
	}

	public int recuperarOpcion(){
		int opcion = GameObject.Find("ListaDesplegable").GetComponent<Dropdown>().value;
		return opcion+1;
	}
}