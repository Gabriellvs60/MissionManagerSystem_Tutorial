using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MissionCarRunCity : MonoBehaviour{

	public bool OnLocal;
	public bool completed;
	public string dialogMission;
	public Text dialog;	
	[SerializeField] MissionCarRescue missionCar;

	[SerializeField] AudioSource source;
	[SerializeField]AudioClip clip;
	[SerializeField] int cont; //conta os plays do som pra limitar a 1 apenas
	// Use this for initialization

	public GameObject continuePanel;
	public MissionTimer missionTimer;
	//Desabilitando Sonorização do carro ao compeltar missão
	[SerializeField] GameObject car;
	[SerializeField] AudioSource[] carAudios;

	void Start () {
		OnLocal = false;
		cont = 0;
	}

	void OnTriggerEnter(Collider col){
		if (col.tag.Equals ("Car")) {
			OnLocal = true;
		}
	}

	void CompleteGame(){
		missionTimer.isCompleted = true;

		Time.timeScale = 0;
		continuePanel.SetActive (true);
		source.PlayOneShot (clip);
	}

	// Update is called once per frame
	void Update () {
		
		if (carAudios.Count () == 0) {
			carAudios = car.GetComponentsInChildren<AudioSource> ();
		}

		if (!missionCar.completed)
			return;

		if (missionCar.completed) {
			dialog.text = dialogMission;

			if (!OnLocal)
				return;

			if (OnLocal == true) {
				if (cont == 0) {
					deactivateSoundCar ();
					CompleteGame ();
					cont++;
				}
				completed = true;
				//Paralizar o jogo
			}
		}
	}

	void deactivateSoundCar(){
		for(int i = 0; i < carAudios.Count(); i++){
			//contabiliza os zumbis que não estão vivos.
			carAudios [i].enabled = false;
		}
	}
}
