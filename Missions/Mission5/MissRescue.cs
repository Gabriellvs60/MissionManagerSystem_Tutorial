using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissRescue : Mission, IComplete
{

	[SerializeField] int Rescueds;
	//contador dos sobreviventes resgatados;
	[SerializeField] int qtdSurvivors;
	//quantia de sobreviventes na missão
	[SerializeField] MissionManager missionMan;

	// Use this for initialization
	void Start ()
	{
		missionMan = FindObjectOfType<MissionManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (isCompleted)
			return;

		if (!isCurrent)
			return;
		
		//se todos forem resgatados, completa a missão.
		if (Rescueds == qtdSurvivors) {
			EndMission ();
		}
	}

	//Completa a missão
	public void EndMission ()
	{
		missionMan.CompleteMission ();
		//Destroy (gameObject);
	}

	public void RescueSurvivor ()
	{
		Rescueds++;
	}


}
