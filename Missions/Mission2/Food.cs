using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	[SerializeField] FoodMission foodMis;

	[SerializeField] AudioSource source;
	[SerializeField]AudioClip clip;

	// Use this for initialization
	void Start () {
		foodMis = GetComponentInParent<FoodMission> ();
	}


	//libera a abertura ou fechamento da porta no script Simple Door
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag.Equals ("Player")) {
			if (foodMis.isCurrent) {
				source.PlayOneShot(clip);
				foodMis.incrementFood ();
				gameObject.GetComponent<MeshRenderer> ().enabled = false;
				//destrói o objeto depois de tocar a trilha
				GameManager.Instance.Timer.Add(() => {
					Destroy(gameObject);
				}, clip.length);
			} else {
				print ("Essa não é a missão atual");
			}
		} 
	}
}
