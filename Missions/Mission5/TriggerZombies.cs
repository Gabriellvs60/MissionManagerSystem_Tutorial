using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZombies : MonoBehaviour {
	//este script deve ativar os zumbis e o sobrevivente quando o player entrar nestes gatilhos.
	[SerializeField] GameObject ai;
	[SerializeField] MissRescue missRescue;
	[SerializeField] Survivor survivor;
	[SerializeField] GameObject survivorActivator;
	[SerializeField] ManagerActivationSurvivors managerSurvivors;
	// Use this for initialization
	void Start () {
		missRescue = GetComponentInParent<MissRescue> ();
		//survivor = GetComponentInChildren<Survivor> ();
	}

	//Se estiver na missão atual, ativa, senão ignora.
	//Não estou barrando a ativação de acordo pela missão, levando em conta que o cenario será limitado.
	void OnTriggerEnter(Collider col){
		if (missRescue.isCurrent) {
			if (col.tag.Equals ("Player")) {
				//ativa o objeto dos zumbis
				if (!managerSurvivors.checkSomebodyActive()){
				if (!ai.activeSelf) {
					ai.SetActive (true);
					managerSurvivors.activateFlag();
				}
			}
		}

		}
			
		//O jogador é obrigado a interagir com o sobrevivente.
		if(survivor.canGo){
			managerSurvivors.deactivateSurvivorFlag();
			Destroy (survivorActivator);
		}
	}
}
