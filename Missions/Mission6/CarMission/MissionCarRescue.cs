using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionCarRescue : MonoBehaviour{

	public bool OnLocal;
	public bool completed;
	public string message;									//mensagem de alerta para o player
	public string dialogMission;
	public Text info;										//Hud De Dialogo
	public Text dialog;	

	[SerializeField] AudioSource source;
	[SerializeField]AudioClip clip;

	// Use this for initialization
	void Start () {
		OnLocal = false;
	}
		
	// Update is called once per frame
	void Update () {
		if (completed)
			return;
		
		dialog.text = dialogMission;

		if (OnLocal) {
			info.text = message;
			if (Input.GetKeyDown (KeyCode.O)) {
				completed = true;
				source.PlayOneShot(clip);
				info.text = "";
				//Destroy (gameObject);
			}
		} else {
			info.text = "";
		}
	}
	
}
