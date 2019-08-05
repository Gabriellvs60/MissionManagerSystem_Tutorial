using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCarStop : MonoBehaviour {

	[SerializeField] int situation;
	//1 Resgate , 2 fuga
	[SerializeField] MissionCarRescue missCar;
	[SerializeField] MissionCarRunCity missRun;

	void OnTriggerExit(Collider col){
		if (col.tag.Equals ("Car") && situation == 1) {
			missCar.OnLocal = false;
		}
		if (col.tag.Equals ("Car") && situation == 2) {
			missRun.OnLocal = false;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag.Equals ("Car") && situation == 1) {
			missCar.OnLocal = true;
		}
		if (col.tag.Equals ("Car") && situation == 2) {
			missRun.OnLocal = true;
		}
	}


}
