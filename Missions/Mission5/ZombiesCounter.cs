using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esse Script vai listar os zumbis pré definidos para atacar o sobrevivente
//Deve Validar se todos já morreram pra poder manipular e liberar o sobrevivente
//Manipular a animação e ativar a opção de diálogo com o jogador.
using System.Linq;

public class ZombiesCounter : MonoBehaviour
{

	public List<ZombieSEnemy> zombies;
	[SerializeField] int alives;
	//zumbis vivos
	[SerializeField] int deads;
	//zumbis mortos
	[SerializeField] Survivor survivor;
	[SerializeField] MissRescue missRescue;
	[SerializeField] public bool isSaved;
	[SerializeField] int spinCount;
	//este parametro conta os giros no update depois de chamar o resgate de sobreviventes, é um limitador d uma vez apenas
	[SerializeField] GameObject survivorActivator;
	 
	// Use this for initialization
	void Start ()
	{
		spinCount = 0;
		missRescue = GetComponentInParent<MissRescue> ();
		alives = zombies.Count (); 
		isSaved = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		countAlives ();
		//muda o estado ao deixar de ser alvo.
		if (isSaved && spinCount < 1) { 	//se está a salvo e o limite é de 1 giro no update;
			survivor.isTarget = false;		//o sobrevivente não é mais alvo
			survivor.canChat = true;		// o sobrevivente está apto a conversar
			print ("posso falar");
			//depois que conversou ele pode ir embora, daí ele fica a salvo.
			if (survivor.canGo) {
				print ("posso ir");
				missRescue.RescueSurvivor ();
				spinCount++;
				//DestroyObject (survivorActivator);
			}
		}
	}

	//conta os zumbis que foram mortos
	void countAlives ()
	{
		deads = 0;

		for (int i = 0; i < zombies.Count (); i++) {
			//contabiliza os zumbis que não estão vivos.
			if (zombies [i].ZombieHealth.IsAlive == false)
				deads++;
		}

		//valida se matou todos os zumbis, só completa a missão depois de interagir.
		if (deads == alives) {
			print ("Salvos");
			isSaved = true;
		}
		//return deads;
	}
}
