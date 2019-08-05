using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheckStation : Door {
	StationMission missionReference;

	void Start(){
		missionReference = GetComponentInParent<StationMission> ();
	}

	//libera a abertura ou fechamento da porta no script Simple Door
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag.Equals ("Player")) {
			if (missionReference.isCurrent) {
				print ("entrei");
				canEnter = true;
			} else {
				print ("Essa não é a missão atual");
			}
			if (missionReference.isCompleted) {
				//Destroy (gameObject);
			}
		} 
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag.Equals ("Player")) {
			//simpleDoor.canOpen = false;
			print("sai");
			canEnter = false;
			if (missionReference.isCompleted) {
				canEnter = false;
			}
		}
	}

	private void Update ()
	{	
		
		if (missionReference.isCompleted) {
			if (contSpin == 0)
				info.text = "";
			//desativa pra nao desperdiçar processamento
			this.gameObject.SetActive(false);
			contSpin++;
			return;
		}

		if (canEnter == true) {
			info.text = message;
			if (Input.GetKeyDown (KeyCode.O)) {
				missionReference.EndMission();
				info.text = "";
				Destroy (gameObject);
			}
		} else {
			info.text = "";
		}
		//info.enabled = canOpen;
	}
}
