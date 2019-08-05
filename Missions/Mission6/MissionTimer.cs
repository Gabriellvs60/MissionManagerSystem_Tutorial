using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using System.Linq;

public class MissionTimer : MonoBehaviour {

	public Text timerText;
	private float secondsCount;
	private int minuteCount;
	private int hourCount;
	[SerializeField] int timeMission;
	public GameObject gameOverPanel;
	public bool isCompleted;

	[SerializeField] GameObject car;
	[SerializeField] AudioSource[] carAudios;

	void Update(){
		if (carAudios.Count () == 0) {
			carAudios = car.GetComponentsInChildren<AudioSource> ();
		}

		UpdateTimerUI();
	}

	//call this on update
	public void UpdateTimerUI(){
		if (isCompleted)
			return;
		
		//set timer UI
		secondsCount += Time.deltaTime;
		timerText.text = minuteCount +"0:"+(int)secondsCount;
		if(secondsCount > timeMission){
			timerText.text = "00:" + timeMission;
			//minuteCount++;
			//secondsCount = 0;
			//deactivateSoundCar ();
			//pausa o jogo
			//AudioListener.volume = 0f;
			deactivateSoundCar();
			Time.timeScale = 0f;
			gameOverPanel.SetActive (true);
	//		source.PlayOneShot (clip);
		}   
	}

	void deactivateSoundCar(){
		for(int i = 0; i < carAudios.Count(); i++){
			//contabiliza os zumbis que não estão vivos.
			carAudios [i].enabled = false;
		}
	}
}
