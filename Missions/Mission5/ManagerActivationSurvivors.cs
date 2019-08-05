using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//quando um sobrevivente é ativado, a flag fica true;
//só é possível ativar um objeto de sobrevivente(S E ZUMBIS) se a flag está false;

public class ManagerActivationSurvivors : MonoBehaviour {
	//se alguém está ativo
	[SerializeField] bool iAmActivated;

	//retorna o valor da flag
	public bool checkSomebodyActive(){
		return iAmActivated;
	}

	//seta a tag como false, pois nao tem nenhum sobrevivente ativo
	public void deactivateSurvivorFlag(){
		iAmActivated = false;
	}

	//seta a flag como true, alguem foi ativado
	public void activateFlag(){
		iAmActivated = true;
	}

}
