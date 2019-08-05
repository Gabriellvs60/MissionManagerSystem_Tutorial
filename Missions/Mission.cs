using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour {
	//variáveis em comum nas missões
	[SerializeField] int id;
	[SerializeField] string name;
	[SerializeField] int level;
	public bool isCompleted;
	public bool isCurrent;
 	public string description;

	public void SetCompleted(){
		isCompleted = true;
		isCurrent = false;
		Debug.Log ("Mission Completed");
	}

	public void ActivateMission(){
		isCurrent = true;
		Debug.Log ("Mission Started");
	}
}
