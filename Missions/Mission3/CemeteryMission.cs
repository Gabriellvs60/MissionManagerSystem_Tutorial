using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class CemeteryMission : Mission, IComplete
{
	[SerializeField] MissionManager missionMan;
	public int weaponQuantity;
	public int weaponRequired;
	// Use this for initialization
	void Start ()
	{
		missionMan = FindObjectOfType<MissionManager> ();
	}
		
	// Update is called once per frame
	void Update () {
		if (isCompleted)
			return;

		if (!isCurrent)
			return;
		
		if (weaponRequired == weaponQuantity && isCurrent){
			EndMission ();
		}
	}

	//finaliza a missão
	public void EndMission ()
	{
		missionMan.CompleteMission ();
		//Destroy (gameObject);
	}

	public void incrementWeapon(){
		weaponQuantity ++;
	}
}
