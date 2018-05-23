using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimentoPersonagem : MonoBehaviour {
	[SerializeField] private float velocidade = 1f;
	private Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
	}

	public void Andar(Vector2 direcao) {
		rb.velocity = direcao * velocidade;
	}
}
