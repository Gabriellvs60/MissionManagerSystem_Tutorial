using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMission : Mission, IComplete {
	[SerializeField] MissionManager missionMan;

	public int foodQuantity;
	public int foodRequired;

	// Use this for initialization
	void Start () {
		missionMan = FindObjectOfType<MissionManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isCompleted)
			return;
		if (!isCurrent)
			return;
		
		if (foodRequired == foodQuantity && isCurrent){
			EndMission ();
		}
}

	public void EndMission(){
		missionMan.CompleteMission ();
		//Destroy (gameObject);
	}

	public void incrementFood(){
		foodQuantity ++;
	}
}
