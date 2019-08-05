using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CemKill : Mission, IComplete {
	[SerializeField] MissionManager missionMan;
	public List<ZombieEnemy> zombies;
	[SerializeField] int alives;	//zumbis vivos
	[SerializeField] int deads;		//zumbis mortos
	[SerializeField] GameObject ai;

	public ZombieAnimation[] zombiesAnim;

	// Use this for initialization
	void Start () {
		GameManager.Instance.Timer.Add(() => {
			ai.SetActive(false);
		}, 5);
		alives = zombies.Count (); //inicializa a variavel com a quantia de zumbis na lista.
		missionMan = FindObjectOfType<MissionManager> ();

		zombiesAnim = ai.GetComponentsInChildren<ZombieAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isCompleted)
			return;

		if (!isCurrent)
			return;
		else {
			//quando se tornar a missão atual, ativa os zumbis que estão desativados até então..
			if (!ai.activeSelf)
				activateAi ();
		}
		//se o valor de mortos é igual ao de vivos, significa que todos morreram.
		if (countAlives() == alives)
			EndMission ();
	}

	//percorre a lista e descobre quantos zumbis ainda estão vivos
	//a meta é zerar os vivos.
	int countAlives(){
		deads = 0;
			for(int i = 0; i < zombies.Count(); i++){
			//contabiliza os zumbis que não estão vivos.
			if (zombies [i].ZombieHealth.IsAlive == false)
				deads++;
		}
		return deads;
	}

	//diz pro manager que a missão está concluida.
	public void EndMission(){
		missionMan.CompleteMission ();
		//Destroy (gameObject);
	}

	void activateAi(){
		if (!ai.activeSelf) {
			ai.SetActive (true);
			ResetAnimator ();
		}
	}

	//reseta o script de animação pro zumbi poder atacar normalmente, assim o animator nao trava.
	void ResetAnimator(){
		for(int i = 0; i < zombiesAnim.Count(); i++){
			//contabiliza os zumbis que não estão vivos.
			zombiesAnim [i].enabled = false;
		}
		for(int i = 0; i < zombies.Count(); i++){
			//contabiliza os zumbis que não estão vivos.
			zombiesAnim [i].enabled = true;
		}
	}
}
