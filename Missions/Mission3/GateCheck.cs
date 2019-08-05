using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateCheck : Door {
	//Esse script valida se a missao atual é referente a do objeto
	//se for, coloca o player dentro do cemitério

	[SerializeField] Mission missionReference; //missão referente ao objeto
	[SerializeField] Player player;
	[SerializeField] Transform playerPosition; //posição desejada para transportar.
	[SerializeField] int requirement;
	//se for 1, usa missionReference.isCurrent, se for 2, usa missionReference.iscompleted;

	//existem duas condições na porta do cemitério, na primeira só libera a entrada com a missão sendo atual
	//na segunda só libera a porta se a missão está cumprida, este é o desafio, tornar estas duas condições validadas no script.

	void Start(){
		missionReference = GetComponentInParent<Mission> ();
		player = FindObjectOfType<Player> ();
		info.text = "";
	}

	//libera a abertura ou fechamento da porta (pela flag booleana)
	void OnTriggerEnter(Collider col){
		int situation = 0;
		if (col.gameObject.tag.Equals ("Player")) {
			//coloca um numero pra determinar se quer a missão completa ou current pra entender qual das duas situações utilizar.
			if (missionReference.isCurrent && requirement == 1) { //se é a atual
				info.text = message;
				this.canEnter = true;
				//print ("entrei");
			}
			if (missionReference.isCompleted && requirement == 2) { //se é a atual
				info.text = message;
				this.canEnter = true;
				//print ("entrei");
			}

			else {
				//print ("Essa não é a missão atual");
			}
		} 

	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag.Equals ("Player")) {
			canEnter = false;
			//simpleDoor.canOpen = false;
			print("sai");
			if (missionReference.isCompleted) {
				//Destroy (gameObject);
			}
		}
	}

	void Update(){
		if (!missionReference.isCurrent && requirement == 1 ) {
			return;
		}
	
		if (canEnter == true) {
			info.text = message;
			if (Input.GetKeyDown (KeyCode.O)) {
				player.transform.position = playerPosition.position;
				info.text = "";
				Destroy (gameObject);
			}
		}
		if (canEnter == false) {
			info.text = "";
		}
	}
}
