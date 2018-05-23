using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadeTiro : MonoBehaviour {
	[SerializeField] private Transform origemTiro;
	[SerializeField] private float velocidade = 3f;
	[SerializeField] private GameObject[] municao;
	
	public void Atirar(int indice) {
		GameObject disparo = Instantiate (municao[indice]);
		disparo.transform.position = origemTiro.position;
		disparo.GetComponent<Rigidbody2D> ().velocity = origemTiro.up * velocidade;
	}
}
