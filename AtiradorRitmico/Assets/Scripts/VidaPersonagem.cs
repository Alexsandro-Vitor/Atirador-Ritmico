using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class VidaPersonagem : MonoBehaviour {
	private int vida;
	[SerializeField] private int vidaMax = 1;

	void Awake () {
		vida = vidaMax;
	}

	public void SofrerDano(int dano) {
		vida -= dano;
		if (vida <= 0) Destroy(gameObject);
	}
}
