using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour {

	//Lista de missões
	//public Mission[] missions;
	public int currentMissionId;
	public string currentMissionDescription;
	public List<Mission> missions;
	//gerenciador de limiters da cena
	//[SerializeField] LimiterManager limiterManager;

	[SerializeField] AudioSource source;
	[SerializeField]AudioClip clip;
	//SetNextMission


	// Use this for initialization
	void Start () {
		//a missão sempre começa na numero 1
		currentMissionId = 1;
		currentMissionDescription = missions [currentMissionId -1].description;
		missions [currentMissionId - 1].isCurrent = true;
		//referenciando o limiterManager
		//limiterManager = FindObjectOfType<LimiterManager> ();
	}

	public void CompleteMission(){
		source.PlayOneShot(clip);
		missions [currentMissionId - 1].SetCompleted ();

		SetNextMission ();
	}

	void SetNextMission(){
		currentMissionId ++;
		//limiterManager.DeactivateLimiter(currentMissionId -1);
		//print (currentMissionId -1 + "ID DA MISSAO");
		currentMissionDescription = missions [currentMissionId -1].description;
		missions [currentMissionId - 1].ActivateMission();
		//destrói o limiter ao setar a nova missão

	}


//	public bool CheckCurrentMission(int id){
//		if (currentMissionId == id)
//			return true;
//		else
//			return false;
//	}

}
