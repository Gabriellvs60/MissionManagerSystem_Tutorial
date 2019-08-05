using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCarMission : Mission, IComplete {
	//O player deve entrar no gatilho pra poder pegar o carro
	//Quando ele pegar o carro, completa a missão o level CarControl
	[SerializeField] MissionManager missionMan;

	void Start ()
	{
		missionMan = FindObjectOfType<MissionManager> ();
	}

	//Completa a missão
	public void EndMission ()
	{
		missionMan.CompleteMission ();
		//Destroy (gameObject);
	}
}
