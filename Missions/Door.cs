using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {
	public int contSpin; //conta voltas do update; para desativar a emissao de textos do Info (de missoes)
	public Text info;				 //referencia do texto da HUD (INFO DO QUE FAZER)
	public bool canEnter = false;	 // quando o player está no gatilho e a missão atual é a correspondente
	public string message; 			 //mensagem exibida no texto da HUD (Info)

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
