using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMission : MonoBehaviour {

	[SerializeField] CemeteryMission cemMis;

	// Use this for initialization
	void Start () {
		cemMis = GetComponentInParent<CemeteryMission> ();
	}
	
	//Completa a missão ao pegar as duas armas
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag.Equals ("Player")) {
			if (cemMis.isCurrent) {
				cemMis.incrementWeapon ();
			} else {
				print ("Essa não é a missão atual");
			}
		} 
	}
}
