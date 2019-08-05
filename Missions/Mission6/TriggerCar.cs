using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerCar : MonoBehaviour {
	[SerializeField] FindCarMission FindCarMission;
	[SerializeField] public bool canInteract;				//chave que libera a a interação.
	public string message;									//mensagem de alerta para o player
	public Text info;										//Hud De Dialogo

	[SerializeField] GameObject loadProgressBar;
	[SerializeField] private string sceneToLoad;

	// Use this for initialization
	void Start () {
		FindCarMission = GetComponentInParent<FindCarMission> ();
	}
	
	void OnTriggerEnter(Collider col){

		if (col.tag.Equals ("Player")) {
			if (FindCarMission.isCurrent) {
				canInteract = true;
			}
		}
	}

		
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag.Equals ("Player")) {
			//simpleDoor.canOpen = false;
			if (FindCarMission.isCurrent) {
				print ("sai");
				canInteract = false;
			}
		}
	}

	void Update(){
		if (!FindCarMission.isCurrent)
			return;
		
		if (canInteract) {
			info.text = message;
			if (Input.GetKeyDown (KeyCode.O)) {
				//Chama a fase da missão 6.
				print ("Missão Cumprida!");
				loadProgressBar.SetActive(false);
				FindObjectOfType<ProgressSceneLoader>().LoadScene(sceneToLoad);
				//SceneManager.LoadScene ();
			}
		} else {
			info.text = "";
		}
	}
}
