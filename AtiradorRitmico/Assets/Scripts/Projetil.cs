using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {
	public int dano = 1;

	void OnTriggerEnter2D(Collider2D col) {
		VidaPersonagem vida = col.GetComponent<VidaPersonagem>();
		if (vida != null) vida.SofrerDano(dano);
		Destroy (gameObject);
	}
}
