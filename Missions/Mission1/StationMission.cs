	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	//herda as variáveis da missão, implemnta o método EndMission.
	public class StationMission : Mission, IComplete
	{
		[SerializeField] MissionManager missionMan;
		private bool doorOpen = false;
		public bool canOpen = false;
		public Player player;
		public Text info;
		public string message;
		public Light[] lights;
		int contSpin;		

		void Start ()
		{
			missionMan = FindObjectOfType<MissionManager> ();
			lights = GetComponentsInChildren<Light> ();
			info.text = "";
			player = FindObjectOfType<Player> ();
		}
		
		public void EndMission ()
		{
			for (int i = 0; i < lights.Length; i++) {
				lights [i].enabled = true;
			}
			missionMan.CompleteMission ();
		}

		public void setOpenEnable (bool value)
		{
			canOpen = value;
		}
	}
